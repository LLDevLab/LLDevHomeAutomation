import { Component, Inject, Input, OnChanges, SimpleChanges } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { ISensorLineChartData, IChartDetails, ISensorGroup } from '../../interfaces';
import { UnitType } from '../../enums';

@Component({
  selector: 'app-line-chart',
  templateUrl: './line-chart.component.html',
  styleUrls: ['./line-chart.component.css']
})
export class LineChartComponent implements OnChanges {
  @Input() chart: IChartDetails;
  @Input() sensorGroup: ISensorGroup;

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
    if (this.sensorGroup === null)
      return;

    this.chartData = [];
    this.loadChartData();
  }

  getYAxisLabel(): string {
    let label = "Value ";
    switch (this.sensorGroup.unitId) {
      case UnitType.DegreeCelsius:
        label += "(\u00B0C)";
        break;
      case UnitType.Pascals:
        label += "(Pa)";
        break;
      case UnitType.Percent:
        label += "(%)";
        break;
      case UnitType.Meters:
        label += "(m)";
        break;
      case UnitType.MetersPerSecond:
        label += "(m/s)";
        break;
      case UnitType.Degree:
        label += "(degree)";
        break;
      default:
        label += "(undefined)";
        break;
    }

    return label;
  }

  onSelect(data): void {
  }

  onActivate(data): void {
  }

  onDeactivate(data): void {
  }

  protected loadChartData(): void {
    this.http.get<ISensorLineChartData<number>[]>(this.baseUrl + 'chart/' + this.chart.id + '/sensorgroup/' + this.sensorGroup.sensorGroupId).subscribe(chartDataResult => {
      this.chartData = this.chartData.concat(chartDataResult);
      this.dataExists = this.dataExists || this.chartData.every(element => element.series.length > 0);
    });
  }
}
