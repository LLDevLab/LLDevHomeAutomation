import { Component, OnInit, Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { forkJoin } from 'rxjs';
import { ChartType } from '../../enums';
import { IChartDetails, ISensorGroup } from '../../interfaces';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.css']
})
export class ChartComponent implements OnInit {

  chart: IChartDetails;
  chartType: ChartType;
  sensorGroups: ISensorGroup[];
  selectedGroupId: number;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private activatedroute: ActivatedRoute) {
    this.selectedGroupId = 0;
  }

  ngOnInit(): void {
    this.activatedroute.params.subscribe(routeParams => {
      this.loadChartDetails(routeParams.id);
    });
  }

  onSelectionChange(event) {
    this.selectedGroupId = event.value;
  }

  getSensorGroup(): ISensorGroup {
    let selectedGroup = null;
    if (this.selectedGroupId > 0) {
      this.sensorGroups.forEach(group => {
        if (group.sensorGroupId === this.selectedGroupId) {
          selectedGroup = group;
          return;
        }
      })
    }

    return selectedGroup;
  }

  private loadChartDetails(chartId: string) {
    forkJoin([this.http.get<IChartDetails>(this.baseUrl + 'chart/' + chartId),
      this.http.get<ISensorGroup[]>(this.baseUrl + 'chart/' + chartId + '/sensorgroups')])
      .subscribe(([chartDetails, chartUnitMappings]) => {
        this.chart = chartDetails;
        this.chartType = chartDetails.id;
        this.sensorGroups = chartUnitMappings;
      }, error => console.error(error));
  }
}
