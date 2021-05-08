import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SensorLineChartComponent } from './sensor-line-chart.component';

describe('SensorChartsComponent', () => {
  let component: SensorLineChartComponent;
  let fixture: ComponentFixture<SensorLineChartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SensorLineChartComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SensorLineChartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
