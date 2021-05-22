import { Component, Inject, Input, OnChanges, SimpleChanges } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { PageEvent } from '@angular/material/paginator';

import { ISensorEvents, ISensorDetails } from '../../interfaces';

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
  public displayedColumns: string[] = ['id', 'value', 'datetime'];
  public pageSize: number;
  public eventsCount: number;

  private pageIndex: number;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string)
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
