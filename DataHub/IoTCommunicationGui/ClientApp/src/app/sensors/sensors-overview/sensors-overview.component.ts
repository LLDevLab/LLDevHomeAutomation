import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { SensorDetails } from '../../interfaces/sensor-details';

@Component({
  selector: 'app-sensors-overview',
  templateUrl: './sensors-overview.component.html',
  styleUrls: ['./sensors-overview.component.css']
})
export class SensorsOverviewComponent {
  public sensors: SensorDetails[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<SensorDetails[]>(baseUrl + 'sensorsoverview').subscribe(result => {
      this.sensors = result;
    }, error => console.error(error));
  }
}
