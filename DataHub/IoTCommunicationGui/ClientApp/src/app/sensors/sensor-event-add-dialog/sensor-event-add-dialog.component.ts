import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';

import { ISensorDetails, ISensorEvents } from '../../interfaces';

@Component({
  selector: 'app-sensor-event-add-dialog',
  templateUrl: './sensor-event-add-dialog.component.html',
  styleUrls: ['./sensor-event-add-dialog.component.css']
})
export class SensorEventAddDialogComponent implements OnInit {

  sensorEvent: ISensorEvents;
  sensorDetails: ISensorDetails;

  dateTimeInput: string;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
    @Inject('BASE_URL') private baseUrl: string,
    private http: HttpClient) { }

  ngOnInit(): void {
    this.sensorDetails = this.data.sensorDetails;

    const isNumericEvent = this.sensorDetails.unitId !== null;

    const dateTimeStr = (new Date()).toISOString();
    this.dateTimeInput = dateTimeStr.substr(0, dateTimeStr.length - 1);

    this.sensorEvent = {
      id: null,
      sensorId: this.sensorDetails.id,
      eventDateTime: null,
      eventDoubleValue: isNumericEvent ? 0 : null,
      eventBooleanValue: !isNumericEvent ? false : null
    }
  }

  boolValChanged(val: boolean) {
    this.sensorEvent.eventBooleanValue = val;
  }

  async onSubmit() {
    this.sensorEvent.eventDateTime = new Date(this.dateTimeInput);
    await this.http.post(this.baseUrl + 'sensor/event', this.sensorEvent).toPromise();
  }
}
