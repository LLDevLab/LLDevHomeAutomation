import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { SensorType } from '../../enums/enums';
import { SensorDetails } from '../../interfaces/sensor-details';

@Component({
  selector: 'app-sensor-details',
  templateUrl: './sensor-details.component.html',
  styleUrls: ['./sensor-details.component.css']
})
export class SensorDetailsComponent implements OnInit {

  public sensor: SensorDetails;
  public sensorType: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private activatedroute: ActivatedRoute) { }

  ngOnInit() {
    this.activatedroute.params.subscribe(routeParams => {
      this.loadSensorDetail(routeParams.id);
    });
  }

  loadSensorDetail(sensorId: string) {
    this.http.get<SensorDetails>(this.baseUrl + 'sensordetails/' + sensorId).subscribe(result => {
      this.sensor = result;
      this.sensorType = SensorType[result.sensorType];
    }, error => console.error(error));
  }
}
