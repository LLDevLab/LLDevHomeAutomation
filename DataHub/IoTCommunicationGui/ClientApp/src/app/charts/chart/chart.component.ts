import { Component, OnInit, Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { forkJoin } from 'rxjs';
import { ChartType } from '../../enums';
import { IChartDetails, IChartUnitMapping } from '../../interfaces';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.css']
})
export class ChartComponent implements OnInit {

  chart: IChartDetails;
  chartType: ChartType;
  chartMappings: IChartUnitMapping[];
  selectedUnitId: number;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private activatedroute: ActivatedRoute) {
    this.selectedUnitId = 0;
  }

  ngOnInit(): void {
    this.activatedroute.params.subscribe(routeParams => {
      this.loadChartDetails(routeParams.id);
    });
  }

  private loadChartDetails(chartId: string) {
    forkJoin([this.http.get<IChartDetails>(this.baseUrl + 'chart/' + chartId),
      this.http.get<IChartUnitMapping[]>(this.baseUrl + 'chart/' + chartId + '/chartunits')])
      .subscribe(([chartDetails, chartUnitMappings]) => {
        this.chart = chartDetails;
        this.chartType = chartDetails.id;
        this.chartMappings = chartUnitMappings;
      }, error => console.error(error));
  }

  onSelectionChange(event) {
    this.selectedUnitId = event.value;
  }
}
