import { Component, Inject, Input, OnChanges, SimpleChanges } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { ISensorLineChartData, IChartUnitMapping, IChartDetails } from '../../interfaces';
import { UnitType } from '../../enums';

@Component({
  selector: 'app-line-chart',
  templateUrl: './line-chart.component.html',
  styleUrls: ['./line-chart.component.css']
})
export class LineChartComponent implements OnChanges {

  @Input() chart: IChartDetails;
  @Input() unitId: number;

  chartData: ISensorLineChartData<number>[];
  dataExists: boolean;

  view: any[] = [1000, 500];

  // options
  legend: boolean = true;
  showLabels: boolean = true;
  animations: boolean = true;
  xAxis: boolean = true;
  yAxis: boolean = true;
  showYAxisLabel: boolean = true;
  showXAxisLabel: boolean = true;
  xAxisLabel: string = 'Date/Time';
  timeline: boolean = true;

  colorScheme = {
    domain: ['#5AA454', '#E44D25', '#CFC0BB', '#7aa3e5', '#a8385d', '#aae3f5']
  };

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.dataExists = false;
    this.chartData = [];
  }

  ngOnChanges() {
    if (this.unitId === 0)
      return;

    this.chartData = [];
    this.http.get<ISensorLineChartData<number>[]>(this.baseUrl + 'chart/' + this.chart.id + '/unit/' + this.unitId).subscribe(chartDataResult => {
      this.chartData = this.chartData.concat(chartDataResult);
      this.dataExists = this.dataExists || this.chartData.every(element => element.series.length > 0);
    });
  }

  getYAxisLabel(): string {
    let label = "Value ";
    switch (this.unitId) {
      case UnitType.DegreeCelsius:
        label += "(\u00B0C)";
        break;
      case UnitType.Pascals:
        label += "(Pa)";
        break;
      default:
        label += "(undefined)";
        break;
    }

    return label;
  }

  onSelect(data): void {
    console.log('Item clicked', JSON.parse(JSON.stringify(data)));
  }

  onActivate(data): void {
    console.log('Activate', JSON.parse(JSON.stringify(data)));
  }

  onDeactivate(data): void {
    console.log('Deactivate', JSON.parse(JSON.stringify(data)));
  }
}
