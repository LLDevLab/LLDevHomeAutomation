import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { NgxChartsModule } from '@swimlane/ngx-charts';

import { ChartComponent } from './chart/chart.component';
import { LineChartComponent } from './line-chart/line-chart.component';


@NgModule({
  declarations: [
    ChartComponent,
    LineChartComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild([
      { path: 'fetch-chart/:id', component: ChartComponent },
    ]),
    MatSelectModule,
    NgxChartsModule
  ],
  exports: [RouterModule]
})
export class ChartsModule { }
