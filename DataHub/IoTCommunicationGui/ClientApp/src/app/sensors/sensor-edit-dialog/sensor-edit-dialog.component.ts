import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

import { UnitType } from '../../enums';
import { ISensorDetails } from '../../interfaces';

@Component({
  selector: 'app-sensor-edit-dialog',
  templateUrl: './sensor-edit-dialog.component.html',
  styleUrls: ['./sensor-edit-dialog.component.css']
})
export class SensorEditDialogComponent {

  sensorDetails: ISensorDetails;
  unitTypes = Object.values(UnitType);

  constructor(@Inject(MAT_DIALOG_DATA) data: any,
    @Inject('BASE_URL') private baseUrl: string,
    private http: HttpClient)
  {
    this.sensorDetails = data.sensorDetails;
  }

  isActiveChanged(isActive: boolean) {
    this.sensorDetails.isActive = isActive;
  }

  inverseLogicChanged(inverseLogic: boolean) {
    this.sensorDetails.inverseLogic = inverseLogic;
  }

  onSubmit() {
    this.http.post(this.baseUrl + 'sensor', this.sensorDetails).subscribe(error => console.error(error));
  }
}
