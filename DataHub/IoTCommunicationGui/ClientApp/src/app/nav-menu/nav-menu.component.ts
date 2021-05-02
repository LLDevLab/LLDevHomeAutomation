import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { SensorDetails } from '../interfaces/sensor-details';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  public sensors: SensorDetails[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<SensorDetails[]>(baseUrl + 'sensorsoverview').subscribe(result => {
      this.sensors = result;
    }, error => console.error(error));
  }
}
