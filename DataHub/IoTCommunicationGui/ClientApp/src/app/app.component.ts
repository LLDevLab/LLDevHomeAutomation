import { Component } from '@angular/core';
import { MenuType } from './enums';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title: string;
  menuType: MenuType;

  constructor() {
    this.title = 'LLDev Home Automation';
    this.menuType = MenuType.Main;
  }

  onSettingsBtnClick() {
    this.menuType = MenuType.Settings;
  }

  onTitleClick() {
    this.menuType = MenuType.Main;
  }
}
