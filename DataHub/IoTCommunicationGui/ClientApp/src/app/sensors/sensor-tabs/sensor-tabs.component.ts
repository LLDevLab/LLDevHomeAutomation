import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { SensorType } from '../../enums';
import { SensorDetails } from '../../interfaces';

@Component({
  selector: 'app-sensor-tabs',
  templateUrl: './sensor-tabs.component.html',
  styleUrls: ['./sensor-tabs.component.css']
})
export class SensorTabsComponent implements OnInit {

  public sensor: SensorDetails;
  public isOnOffSensor: boolean;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private activatedroute: ActivatedRoute) { }

  ngOnInit(): void {
    this.activatedroute.params.subscribe(routeParams => {
      this.loadSensorDetail(routeParams.id);
    });
  }

  loadSensorDetail(sensorId: string) {
    this.http.get<SensorDetails>(this.baseUrl + 'sensordetails/' + sensorId).subscribe(result => {
      this.sensor = result;
      this.isOnOffSensor = result.sensorType === SensorType.OnOffSensor;
    }, error => console.error(error));
  }
}
