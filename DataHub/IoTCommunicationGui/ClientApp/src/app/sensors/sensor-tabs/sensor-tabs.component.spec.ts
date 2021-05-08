import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SensorTabsComponent } from './sensor-tabs.component';

describe('SensorTabsComponent', () => {
  let component: SensorTabsComponent;
  let fixture: ComponentFixture<SensorTabsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SensorTabsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SensorTabsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
