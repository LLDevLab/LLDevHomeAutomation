import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { SensorEventsComponent } from './sensor-events/sensor-events.component';
import { SensorsOverviewComponent } from './sensors-overview/sensors-overview.component';
import { SensorDetailsComponent } from './sensor-details/sensor-details.component';


@NgModule({
  declarations: [
    SensorEventsComponent,
    SensorsOverviewComponent,
    SensorDetailsComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild([
      {
        path: 'fetch-sensors', component: SensorsOverviewComponent, children: [
          { path: 'fetch-sensordetails/:id', component: SensorDetailsComponent }
        ]
      },
      { path: 'fetch-sensorevents', component: SensorEventsComponent },
    ])
  ],
  exports: [RouterModule]
})
export class SensorsModule { }
