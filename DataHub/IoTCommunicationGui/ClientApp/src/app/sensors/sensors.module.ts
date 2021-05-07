import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { MatTabsModule } from '@angular/material/tabs';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';

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
    MatTabsModule,
    MatTableModule,
    MatPaginatorModule
  ],
  exports: [RouterModule]
})
export class SensorsModule { }
