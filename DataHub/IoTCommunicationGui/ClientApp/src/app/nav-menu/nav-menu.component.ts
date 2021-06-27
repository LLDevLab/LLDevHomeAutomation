import { Component, Input, OnChanges, SimpleChanges } from '@angular/core';

import { MenuType } from '../enums';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnChanges {
  @Input() menuType: MenuType;

  constructor() {
  }

  ngOnChanges(changes: SimpleChanges) {
    if (typeof changes.menuType.currentValue === "undefined")
      return;
  }
}
