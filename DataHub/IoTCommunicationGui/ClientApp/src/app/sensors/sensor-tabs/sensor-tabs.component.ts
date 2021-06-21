import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { MatDialog } from '@angular/material/dialog';

import { ISensorDetails } from '../../interfaces';
import { SensorEditDialogComponent } from '../sensor-edit-dialog/sensor-edit-dialog.component';

@Component({
  selector: 'app-sensor-tabs',
  templateUrl: './sensor-tabs.component.html',
  styleUrls: ['./sensor-tabs.component.css']
})
export class SensorTabsComponent implements OnInit {

  public sensor: ISensorDetails;
  public isOnOffSensor: boolean;

  constructor(public dialog: MatDialog, private http: HttpClient, private location: Location,
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

  onEditBtnClick() {
    const _this = this;
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

      if(sensor !== null)
        this.sensor = sensor;
    });
  }
}
