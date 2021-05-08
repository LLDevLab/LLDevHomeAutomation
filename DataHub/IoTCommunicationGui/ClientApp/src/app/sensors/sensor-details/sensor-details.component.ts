import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';

import { SensorType, UnitType } from '../../enums';
import { SensorDetails } from '../../interfaces';

export interface SensorFields {
  label: string;
  value: string;
}

@Component({
  selector: 'app-sensor-details',
  templateUrl: './sensor-details.component.html',
  styleUrls: ['./sensor-details.component.css']
})
export class SensorDetailsComponent implements OnChanges {

  @Input() sensor: SensorDetails;

  public sensorType: string;
  public unitType: string;

  displayedColumns: string[] = ['label', 'value'];
  sensorFields: SensorFields[];

  constructor() { }

  ngOnChanges(changes: SimpleChanges) {
    if (typeof changes.sensor.currentValue === "undefined")
      return;

    this.sensorType = SensorType[this.sensor.sensorType];
    this.unitType = this.sensor.unitId === null ? 'Undefined' : UnitType[this.sensor.unitId];

    this.sensorFields = [];
    this.initSensorFields();
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
