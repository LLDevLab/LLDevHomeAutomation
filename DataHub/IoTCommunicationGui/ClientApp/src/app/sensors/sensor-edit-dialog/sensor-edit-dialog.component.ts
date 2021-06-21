import { Component, OnInit, Inject } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { UnitType } from '../../enums';

import { ISensorDetails } from '../../interfaces';

@Component({
  selector: 'app-sensor-edit-dialog',
  templateUrl: './sensor-edit-dialog.component.html',
  styleUrls: ['./sensor-edit-dialog.component.css']
})
export class SensorEditDialogComponent implements OnInit {

  sensorDetails: ISensorDetails;
  unitTypes = Object.values(UnitType);
  descFormControl: FormControl;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, @Inject('BASE_URL') private baseUrl: string, private http: HttpClient)
  {
  }

  ngOnInit(): void {
    this.sensorDetails = this.data.sensorDetails;

    this.descFormControl = new FormControl(this.sensorDetails.description, [
      Validators.required
    ]);
  }

  isActiveChanged(isActive: boolean) {
    this.sensorDetails.isActive = isActive;
  }

  inverseLogicChanged(inverseLogic: boolean) {
    this.sensorDetails.inverseLogic = inverseLogic;
  }

  onSubmit() {
    this.sensorDetails.description = this.descFormControl.value;
    this.http.post(this.baseUrl + 'sensor', this.sensorDetails).subscribe(error => console.error(error));
  }
}
