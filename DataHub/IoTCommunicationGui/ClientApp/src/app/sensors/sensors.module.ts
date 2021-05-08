import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { MatTabsModule } from '@angular/material/tabs';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';

import { NgxChartsModule } from '@swimlane/ngx-charts';

import { SensorEventsComponent } from './sensor-events/sensor-events.component';
import { SensorDetailsComponent } from './sensor-details/sensor-details.component';
import { SensorTabsComponent } from './sensor-tabs/sensor-tabs.component';
import { SensorLineChartComponent } from './sensor-line-chart/sensor-line-chart.component';

@NgModule({
  declarations: [
    SensorEventsComponent,
    SensorDetailsComponent,
    SensorTabsComponent,
    SensorLineChartComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild([
      { path: 'fetch-sensordetails/:id', component: SensorTabsComponent },
    ]),
    MatTabsModule,
    MatTableModule,
    MatPaginatorModule,
    NgxChartsModule
  ],
  exports: [RouterModule]
})
export class SensorsModule { }
