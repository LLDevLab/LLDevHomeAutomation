import { Component, Inject, Input, OnChanges, SimpleChanges } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { ISensorLineChartData, IChartDetails } from '../../interfaces';
import { LineChartBase } from '../../classes/charts/line-chart-base';

@Component({
  selector: 'app-line-chart',
  templateUrl: '../../classes/charts/line-chart.component.html',
  styleUrls: ['../../classes/charts/line-chart.component.css']
})
export class LineChartComponent extends LineChartBase implements OnChanges {
  @Input() chart: IChartDetails;
  @Input() unitId: number;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    super(http, baseUrl);
  }

  ngOnChanges(changes: SimpleChanges) {
    this.onDataChanged(changes);
  }

  protected onDataChanged(changes: SimpleChanges): void {
    if (this.unitId === 0)
      return;

    super.onDataChanged(changes);
  }

  protected getUnitId(): number {
    return this.unitId;
  }

  protected loadChartData(): void {
    this.http.get<ISensorLineChartData<number>[]>(this.baseUrl + 'chart/' + this.chart.id + '/unit/' + this.unitId).subscribe(chartDataResult => {
      this.chartData = this.chartData.concat(chartDataResult);
      this.dataExists = this.dataExists || this.chartData.every(element => element.series.length > 0);
    });
  }
}
