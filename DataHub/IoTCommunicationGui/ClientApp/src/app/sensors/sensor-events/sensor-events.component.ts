import { Component, Inject, Input, OnChanges, SimpleChanges } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatDialog } from '@angular/material/dialog';

import { PageEvent } from '@angular/material/paginator';

import { ISensorEvents, ISensorDetails } from '../../interfaces';
import { SensorEventAddDialogComponent } from '../sensor-event-add-dialog/sensor-event-add-dialog.component';

import { RemoveDialogComponent } from '../remove-dialog/remove-dialog.component';

@Component({
  selector: 'app-sensor-events',
  templateUrl: './sensor-events.component.html',
  styleUrls: ['./sensor-events.component.css']
})
export class SensorEventsComponent implements OnChanges {

  @Input() sensor: ISensorDetails;

  public sensorEvents: ISensorEvents[];
  public eventsExists: boolean;
  public eventValue: string;
  public displayedColumns: string[] = ['id', 'value', 'datetime', 'delbtn'];
  public pageSize: number;
  public eventsCount: number;

  private pageIndex: number;

  constructor(public dialog: MatDialog, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string)
  {
    this.pageSize = 5;
    this.pageIndex = 0;
    this.eventsCount = 0;
  }

  ngOnChanges(changes: SimpleChanges) {
    if (typeof changes.sensor.currentValue === "undefined")
      return;

    this.loadSensorEvents();
  }

  getEventValue(event: ISensorEvents): string {
    let result = 'Undefined';
    if (event.eventBooleanValue !== null)
      result = event.eventBooleanValue ? 'On' : 'Off';
    else if (event.eventDoubleValue !== null)
      result = this.roundNum(event.eventDoubleValue).toString();

    return result;
  }

  onPageEvent(pageEvent: PageEvent) {
    this.pageSize = pageEvent.pageSize;
    this.pageIndex = pageEvent.pageIndex;
    this.loadSensorEvents();
  }

  onAddBtnClick() {
    const dialogRef = this.dialog.open(SensorEventAddDialogComponent, {
      data: {
        sensorDetails: {
          id: this.sensor.id,
          name: this.sensor.name,
          description: this.sensor.description,
          isActive: this.sensor.isActive,
          inverseLogic: this.sensor.inverseLogic,
          sensorGroupName: this.sensor.sensorGroupName,
          unitId: this.sensor.unitId
        }
      }
    });

    dialogRef.afterClosed().subscribe((data) => {
      if (data !== null) {
        this.loadSensorEvents();
      }
    });
  }

  onDeleteBtnClick(event, sensorEvent) {
    event.stopPropagation();

    const dialogRef = this.dialog.open(RemoveDialogComponent, {
      data: {
        elementName: 'sensor event'
      }
    });

    dialogRef.afterClosed().subscribe((data) => {
      if (data === true) {
        this.http.delete(this.baseUrl + 'sensor/event/' + sensorEvent.id).subscribe(error => console.error(error));

        const newEvents: ISensorEvents[] = [];

        this.sensorEvents.forEach(tmpEvent => {
          if (tmpEvent.id !== sensorEvent.id)
            newEvents.push(tmpEvent);
        });
        this.sensorEvents = newEvents;
      }
    });
  }

  private loadSensorEvents() {
    this.http.get<number>(this.baseUrl + 'sensor/' + this.sensor.id + '/events').subscribe(result => {
      this.eventsCount = result;

      this.http.get<ISensorEvents[]>(this.baseUrl + 'sensor/' + this.sensor.id + '/events/' + this.pageSize + '&' + this.pageIndex).subscribe(result => {
        this.sensorEvents = result;
        this.eventsExists = this.sensorEvents.length > 0;
      }, error => console.error(error));
    }, error => console.error(error));
  }

  private roundNum(num: number): number {
    return Math.round(num * 100) / 100;
  }
}
