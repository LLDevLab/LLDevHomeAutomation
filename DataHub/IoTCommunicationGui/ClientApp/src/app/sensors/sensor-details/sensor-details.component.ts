import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { forEachChild } from 'typescript/lib/tsserverlibrary';

import { SensorType, UnitType } from '../../enums/enums';
import { SensorDetails } from '../../interfaces/sensor-details';

export interface SensorFields {
  label: string;
  value: string;
}

@Component({
  selector: 'app-sensor-details',
  templateUrl: './sensor-details.component.html',
  styleUrls: ['./sensor-details.component.css']
})
export class SensorDetailsComponent implements OnInit {

  public sensor: SensorDetails;
  public sensorType: string;
  public unitType: string;

  displayedColumns: string[] = ['label', 'value'];
  sensorFields: SensorFields[];

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

      this.sensorFields = [];
      this.initSensorFields();
    }, error => console.error(error));
  }

  initSensorFields() {
    this.sensorFields.push({
      label: 'Name:', value: this.sensor.name
    });
    this.sensorFields.push({
      label: 'Description:', value: this.sensor.description
    });
    this.sensorFields.push({
      label: 'Sensor type:', value: this.sensorType
    });
    this.sensorFields.push({
      label: 'Unit type:', value: this.unitType
    });
    this.sensorFields.push({
      label: 'Is active:', value: String(this.sensor.isActive)
    });

    if (this.sensor.inverseLogic) {
      this.sensorFields.push({
        label: 'Inverse logic:', value: String(this.sensor.inverseLogic)
      });
    }
  }
}
