import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';

import { UnitType } from '../../enums';
import { ISensorDetails } from '../../interfaces';
import { SensorEditDialogComponent } from '../sensor-edit-dialog/sensor-edit-dialog.component';

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

  @Input() sensor: ISensorDetails;

  public sensorType: string;
  public unitType: string;

  displayedColumns: string[] = ['label', 'value'];
  sensorFields: SensorFields[];

  constructor(public dialog: MatDialog) { }

  ngOnChanges(changes: SimpleChanges) {
    if (typeof changes.sensor.currentValue === "undefined")
      return;

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
      label: 'Unit type:', value: this.unitType
    });
    this.sensorFields.push({
      label: 'Sensor group:', value: this.sensor.sensorGroupName
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

  onEditBtnClick() {
    const dialogRef = this.dialog.open(SensorEditDialogComponent, {
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
      const sensor = data as ISensorDetails;

      if (sensor !== null)
        this.sensor = sensor;
    });
  }
}
