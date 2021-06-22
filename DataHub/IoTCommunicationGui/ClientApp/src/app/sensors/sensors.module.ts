import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { MatTabsModule } from '@angular/material/tabs';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatListModule } from '@angular/material/list';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSelectModule } from '@angular/material/select';

import { NgxChartsModule } from '@swimlane/ngx-charts';

import { SensorEventsComponent } from './sensor-events/sensor-events.component';
import { SensorDetailsComponent } from './sensor-details/sensor-details.component';
import { SensorTabsComponent } from './sensor-tabs/sensor-tabs.component';
import { SensorSelectionComponent } from './sensor-selection/sensor-selection.component';
import { SensorEditDialogComponent } from './sensor-edit-dialog/sensor-edit-dialog.component';
import { SensorAddDialogComponent } from './sensor-add-dialog/sensor-add-dialog.component';

@NgModule({
  declarations: [
    SensorEventsComponent,
    SensorDetailsComponent,
    SensorTabsComponent,
    SensorSelectionComponent,
    SensorEditDialogComponent,
    SensorAddDialogComponent
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
    MatDialogModule,
    MatInputModule,
    MatCheckboxModule,
    MatSelectModule,
    NgxChartsModule
  ],
  exports: [RouterModule]
})
export class SensorsModule { }
