import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { MatTabsModule } from '@angular/material/tabs';

import { SensorEventsComponent } from './sensor-events/sensor-events.component';
import { SensorDetailsComponent } from './sensor-details/sensor-details.component';


@NgModule({
  declarations: [
    SensorEventsComponent,
    SensorDetailsComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild([
      { path: 'fetch-sensordetails/:id', component: SensorDetailsComponent },
      { path: 'fetch-sensorevents', component: SensorEventsComponent }
    ]),
    MatTabsModule
  ],
  exports: [RouterModule]
})
export class SensorsModule { }
