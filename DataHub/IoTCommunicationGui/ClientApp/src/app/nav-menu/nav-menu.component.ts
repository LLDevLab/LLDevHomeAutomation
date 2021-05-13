import { FlatTreeControl } from '@angular/cdk/tree';
import { Component, Inject } from '@angular/core';
import { MatTreeFlatDataSource, MatTreeFlattener } from '@angular/material/tree';
import { HttpClient } from '@angular/common/http';

import { SensorDetails } from '../interfaces';

interface SensorsNode {
  id?: number;
  name: string;
  children?: SensorsNode[];
}

interface FlatNode {
  expandable: boolean;
  id?: number;
  name: string;
  level: number;
}

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  private _transformer = (node: SensorsNode, level: number) => {
    return {
      expandable: !!node.children && node.children.length > 0,
      id: node.id,
      name: node.name,
      level: level,
    };
  }

  sensors: SensorDetails[];

  treeControl = new FlatTreeControl<FlatNode>(
    node => node.level, node => node.expandable);

  treeFlattener = new MatTreeFlattener(
    this._transformer, node => node.level, node => node.expandable, node => node.children);

  dataSource = new MatTreeFlatDataSource(this.treeControl, this.treeFlattener);

  hasChild = (_: number, node: FlatNode) => node.expandable;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<SensorDetails[]>(baseUrl + 'sensor').subscribe(result => {
      this.sensors = result;
      let rootNode: SensorsNode = {
        name: 'Sensors',
        children: []
      };
      this.sensors.forEach(function (value) {
        const data: SensorsNode = {
          id: value.id,
          name: value.name
        };
        rootNode.children.push(data);
      });
      this.dataSource.data = [rootNode];
    }, error => console.error(error));
  }
}
