import { Component, OnInit, Inject } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

import { UnitType } from '../../enums';
import { ISensorDetails } from '../../interfaces';

@Component({
  selector: 'app-sensor-add-dialog',
  templateUrl: './sensor-add-dialog.component.html',
  styleUrls: ['./sensor-add-dialog.component.css']
})
export class SensorAddDialogComponent implements OnInit {

  sensorDetails: ISensorDetails;
  unitTypeNumKeys = Object.keys(UnitType).map(x => parseInt(x)).filter(x => !isNaN(x));
  unitTypeStrKeys = Object.keys(UnitType).filter(x => isNaN(parseInt(x)));
  nameFormControl: FormControl;
  descFormControl: FormControl;
  groupNameFormControl: FormControl;

  constructor(@Inject('BASE_URL') private baseUrl: string, private http: HttpClient) { }

  ngOnInit(): void {
    this.sensorDetails = {
      id: null,
      name: "",
      description: "",
      inverseLogic: null,
      isActive: true,
      sensorGroupName: "",
      unitId: UnitType.Undefined
    };

    this.initFormControls();
  }

  isActiveChanged(isActive: boolean) {
    this.sensorDetails.isActive = isActive;
  }

  inverseLogicChanged(inverseLogic: boolean) {
    this.sensorDetails.inverseLogic = inverseLogic;
  }

  async onSubmit() {
    await this.http.post(this.baseUrl + 'sensor', this.sensorDetails).toPromise();
  }

  private initFormControls(): void {
    this.nameFormControl = new FormControl(this.sensorDetails.name, [
      Validators.required
    ]);

    this.descFormControl = new FormControl(this.sensorDetails.description, [
      Validators.required
    ]);

    this.groupNameFormControl = new FormControl(this.sensorDetails.sensorGroupName, [
      Validators.required
    ]);
  }
}
