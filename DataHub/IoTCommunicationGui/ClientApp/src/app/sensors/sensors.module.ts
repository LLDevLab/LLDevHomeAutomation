import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { MatTabsModule } from '@angular/material/tabs';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatListModule } from '@angular/material/list';
import { MatButtonModule } from '@angular/material/button';

import { NgxChartsModule } from '@swimlane/ngx-charts';

import { SensorEventsComponent } from './sensor-events/sensor-events.component';
import { SensorDetailsComponent } from './sensor-details/sensor-details.component';
import { SensorTabsComponent } from './sensor-tabs/sensor-tabs.component';
import { SensorSelectionComponent } from './sensor-selection/sensor-selection.component';

@NgModule({
  declarations: [
    SensorEventsComponent,
    SensorDetailsComponent,
    SensorTabsComponent,
    SensorSelectionComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild([
      { path: 'sensor-selection', component: SensorSelectionComponent },
      { path: 'sensor-selection/fetch-sensor/:id', component: SensorTabsComponent }
    ]),
    MatTabsModule,
    MatTableModule,
    MatPaginatorModule,
    MatListModule,
    MatButtonModule,
    NgxChartsModule
  ],
  exports: [RouterModule]
})
export class SensorsModule { }
