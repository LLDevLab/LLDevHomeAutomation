import { Component, OnInit } from '@angular/core';

interface ISettingsMenuItem {
  name: string;
  path: string;
}

@Component({
  selector: 'app-menu-settings',
  templateUrl: './menu-settings.component.html',
  styleUrls: ['./menu-settings.component.css']
})
export class MenuSettingsComponent implements OnInit {
  settingsMenuItems: ISettingsMenuItem[];

  constructor() {  }

  ngOnInit(): void {
    this.settingsMenuItems = [{
      name: 'Charts',
      path: 'charts'
    }, {
      name: 'Measurement units',
      path: 'measurement-units'
    }, {
      name: 'Sensor groups',
      path: 'sensor-groups'
    }, {
      name: 'Mapping',
      path: 'mapping'
    }
    ];
  }

}
