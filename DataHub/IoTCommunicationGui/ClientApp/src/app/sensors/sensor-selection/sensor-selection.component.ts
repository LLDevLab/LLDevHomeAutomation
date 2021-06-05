import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { ISensorDetails } from '../../interfaces';

@Component({
  selector: 'app-sensor-selection',
  templateUrl: './sensor-selection.component.html',
  styleUrls: ['./sensor-selection.component.css']
})
export class SensorSelectionComponent implements OnInit {
  sensors: ISensorDetails[];

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  ngOnInit(): void {
    this.http.get<ISensorDetails[]>(this.baseUrl + 'sensor').subscribe((sensorsData) => {
      this.sensors = sensorsData;
    }, error => console.error(error));
  }
}
