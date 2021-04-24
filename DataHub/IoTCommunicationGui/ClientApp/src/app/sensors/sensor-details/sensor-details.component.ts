import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { SensorType, UnitType } from '../../enums/enums';
import { SensorDetails } from '../../interfaces/sensor-details';

@Component({
  selector: 'app-sensor-details',
  templateUrl: './sensor-details.component.html',
  styleUrls: ['./sensor-details.component.css']
})
export class SensorDetailsComponent implements OnInit {

  public sensor: SensorDetails;
  public sensorType: string;
  public unitType: string;

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
      this.unitType = result.unitId === null ? 'Undefined' : UnitType[result.unitId];
    }, error => console.error(error));
  }
}
