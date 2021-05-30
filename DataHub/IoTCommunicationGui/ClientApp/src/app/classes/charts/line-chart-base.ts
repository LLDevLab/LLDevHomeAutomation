import { SimpleChanges } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { ISensorLineChartData } from '../../interfaces';
import { UnitType } from '../../enums';


export abstract class LineChartBase {
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

  constructor(protected http: HttpClient, protected baseUrl: string) {
    this.dataExists = false;
    this.chartData = [];
  }

  getYAxisLabel(): string {
    let label = "Value ";
    switch (this.getUnitId()) {
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

  protected onDataChanged(changes: SimpleChanges): void {
    this.chartData = [];
    this.loadChartData();
  }

  protected abstract getUnitId(): number;
  protected abstract loadChartData(): void;
}
