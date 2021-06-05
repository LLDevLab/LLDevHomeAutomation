import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

import { ISensorDetails } from '../../interfaces';

@Component({
  selector: 'app-sensor-tabs',
  templateUrl: './sensor-tabs.component.html',
  styleUrls: ['./sensor-tabs.component.css']
})
export class SensorTabsComponent implements OnInit {

  public sensor: ISensorDetails;
  public isOnOffSensor: boolean;

  constructor(private http: HttpClient, private location: Location,
    @Inject('BASE_URL') private baseUrl: string, private activatedroute: ActivatedRoute) { }

  ngOnInit(): void {
    this.activatedroute.params.subscribe(routeParams => {
      this.loadSensorDetail(routeParams.id);
    });
  }

  loadSensorDetail(sensorId: string) {
    this.http.get<ISensorDetails>(this.baseUrl + 'sensor/' + sensorId).subscribe(result => {
      this.sensor = result;
      this.isOnOffSensor = result.inverseLogic !== null;
    }, error => console.error(error));
  }

  onBackBtnClick() {
    this.location.back();
  }
}
