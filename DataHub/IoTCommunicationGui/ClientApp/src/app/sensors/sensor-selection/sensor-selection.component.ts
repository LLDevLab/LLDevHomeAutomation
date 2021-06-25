import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatDialog } from '@angular/material/dialog';

import { ISensorDetails } from '../../interfaces';
import { SensorAddDialogComponent } from '../sensor-add-dialog/sensor-add-dialog.component';
import { SensorRemoveDialogComponent } from '../sensor-remove-dialog/sensor-remove-dialog.component';

@Component({
  selector: 'app-sensor-selection',
  templateUrl: './sensor-selection.component.html',
  styleUrls: ['./sensor-selection.component.css']
})
export class SensorSelectionComponent implements OnInit {
  sensors: ISensorDetails[];

  constructor(public dialog: MatDialog, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit(): void {
    this.initSensors();
  }

  onAddBtnClick() {
    const dialogRef = this.dialog.open(SensorAddDialogComponent, null);

    dialogRef.afterClosed().subscribe((data) => {
      const sensor = data as ISensorDetails;

      if (sensor !== null) {
        this.initSensors();
      }
    });
  }

  onDeleteBtnClick(event, sensor) {
    event.stopPropagation();

    const dialogRef = this.dialog.open(SensorRemoveDialogComponent, null);

    dialogRef.afterClosed().subscribe((data) => {
      if (data === true) {
        this.http.delete(this.baseUrl + 'sensor/' + sensor.id).subscribe(error => console.error(error));

        const newSensors: ISensorDetails[] = [];

        this.sensors.forEach(tmpSensor => {
          if (tmpSensor.id != sensor.id)
            newSensors.push(tmpSensor);
        });
        this.sensors = newSensors;
      }
    });
  }

  private initSensors(): void {
    this.http.get<ISensorDetails[]>(this.baseUrl + 'sensor').subscribe((sensorsData) => {
      this.sensors = sensorsData;
    }, error => console.error(error));
  }
}
