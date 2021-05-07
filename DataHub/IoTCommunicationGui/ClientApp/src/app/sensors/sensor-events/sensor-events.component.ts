import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

import { SensorEvents } from '../../interfaces/sensor-events';

import { PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-sensor-events',
  templateUrl: './sensor-events.component.html',
  styleUrls: ['./sensor-events.component.css']
})
export class SensorEventsComponent implements OnInit {
  public sensorEvents: SensorEvents[];
  public eventsExists: boolean;
  public eventValue: string;
  public displayedColumns: string[] = ['id', 'value', 'datetime'];
  public pageSize: number;
  public eventsCount: number;

  private pageIndex: number;
  private sensorId: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private activatedRoute: ActivatedRoute)
  {
    this.pageSize = 5;
    this.pageIndex = 0;
    this.eventsCount = 0;
  }

  getEventValue(event: SensorEvents): string {
    let result = 'Undefined';
    if (event.eventBooleanValue !== null)
      result = event.eventBooleanValue ? 'On' : 'Off';
    else if (event.eventDoubleValue !== null)
      result = this.roundNum(event.eventDoubleValue).toString();

    return result;
  }

  ngOnInit() {
    this.activatedRoute.params.subscribe(routeParams => {
      this.loadSensorEvents(routeParams.id);
    });
  }

  loadSensorEvents(sensorId: string) {
    this.sensorId = sensorId;
    this.http.get<number>(this.baseUrl + 'sensorevents/' + sensorId).subscribe(result => {
      this.eventsCount = result;

      this.http.get<SensorEvents[]>(this.baseUrl + 'sensorevents/' + sensorId + '&' + this.pageSize + '&' + this.pageIndex).subscribe(result => {
        this.sensorEvents = result;
        this.eventsExists = this.sensorEvents.length > 0;
      }, error => console.error(error));
    }, error => console.error(error));
  }

  onPageEvent(pageEvent: PageEvent) {
    this.pageSize = pageEvent.pageSize;
    this.pageIndex = pageEvent.pageIndex;
    this.loadSensorEvents(this.sensorId);
  }

  private roundNum(num: number): number {
    return Math.round(num * 100) / 100;
  }
}
