import { Component, Inject, Input, SimpleChanges } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { ISensorDetails, ISensorLineChartData } from '../../interfaces';
import { LineChartBase } from '../../classes/charts/line-chart-base';

@Component({
  selector: 'app-sensor-line-chart',
  templateUrl: '../../classes/charts/line-chart.component.html',
  styleUrls: ['../../classes/charts/line-chart.component.css']
})
export class SensorLineChartComponent extends LineChartBase {
  @Input() sensor: ISensorDetails;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    super(http, baseUrl)
  }

  ngOnChanges(changes: SimpleChanges) {
    if (typeof changes.sensor.currentValue === "undefined")
      return;

    super.ngOnChanges(changes);
  }

  protected loadChartData(): void {
    this.http.get<ISensorLineChartData<number>[]>(this.baseUrl + 'chart/sensor/' + this.sensor.id).subscribe(result => {
      this.chartData = result;
      this.dataExists = this.chartData.every(element => element.series.length > 0);
    }, error => console.error(error));
  }

  protected getUnitId(): number {
    return this.sensor.unitId;
  }
}
