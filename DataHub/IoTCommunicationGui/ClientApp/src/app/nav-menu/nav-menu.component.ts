import { FlatTreeControl } from '@angular/cdk/tree';
import { Component, Inject } from '@angular/core';
import { MatTreeFlatDataSource, MatTreeFlattener } from '@angular/material/tree';
import { HttpClient } from '@angular/common/http';
import { forkJoin } from 'rxjs';

import { ISensorDetails, IChartDetails, INamedTable } from '../interfaces';

interface IMenuItem {
  id?: number;
  name: string;
  fetchUrl: string,
  children?: IMenuItem[];
}

interface IFlatNode {
  expandable: boolean;
  id?: number;
  name: string;
  level: number;
  fetchUrl: string;
}

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  private _transformer = (node: IMenuItem, level: number) => {
    return {
      expandable: !!node.children && node.children.length > 0,
      id: node.id,
      name: node.name,
      level: level,
      fetchUrl: node.fetchUrl
    };
  }

  sensors: ISensorDetails[];
  charts: IChartDetails[];

  treeControl = new FlatTreeControl<IFlatNode>(
    node => node.level, node => node.expandable);

  treeFlattener = new MatTreeFlattener(
    this._transformer, node => node.level, node => node.expandable, node => node.children);

  dataSource = new MatTreeFlatDataSource(this.treeControl, this.treeFlattener);

  hasChild = (_: number, node: IFlatNode) => node.expandable;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    forkJoin([http.get<ISensorDetails[]>(baseUrl + 'sensor'), http.get<IChartDetails[]>(baseUrl + 'chart')])
      .subscribe(([sensorsData, chartsData]) => {
        this.sensors = sensorsData;
        this.charts = chartsData;
        this.initMenuItems();
      }, error => console.error(error));
  }

  private initMenuItems() {
    const sensorMenuItem: INamedTable = {
      id: -1,
      name: 'Sensor selection'
    };
    const sensorsMenuItems = this.getMenuItem([sensorMenuItem], 'Sensors', 'sensor-selection');
    const chartsMenuItems = this.getMenuItem(this.charts, 'Charts', 'fetch-chart');

    this.dataSource.data = [sensorsMenuItems, chartsMenuItems];
  }

  private getMenuItem(values: INamedTable[], rootNodeName: string, fetchUrl: string): IMenuItem {
    const menuItems: IMenuItem = {
      name: rootNodeName,
      fetchUrl: fetchUrl,
      children: []
    };

    values.forEach(function (value) {
      const data: IMenuItem = {
        id: value.id < 0 ? null : value.id,
        fetchUrl: fetchUrl,
        name: value.name
      };
      menuItems.children.push(data);
    });

    return menuItems;
  }
}
