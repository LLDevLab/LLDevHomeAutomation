import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

import { SensorEvents } from '../../interfaces/sensor-events';

@Component({
  selector: 'app-sensor-events',
  templateUrl: './sensor-events.component.html'
})
export class SensorEventsComponent implements OnInit {
  public sensorEvents: SensorEvents[];
  public eventsExists: boolean;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.activatedRoute.params.subscribe(routeParams => {
      this.loadSensorEvents(routeParams.id);
    });
  }

  loadSensorEvents(sensorId: string) {
    this.http.get<SensorEvents[]>(this.baseUrl + 'sensorevents/' + sensorId).subscribe(result => {
      this.sensorEvents = result;
      this.eventsExists = this.sensorEvents.length > 0;
    }, error => console.error(error));
  }
}
