import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SensorsOverviewComponent } from './sensors-overview.component';

describe('SensorsOverviewComponent', () => {
  let component: SensorsOverviewComponent;
  let fixture: ComponentFixture<SensorsOverviewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [SensorsOverviewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SensorsOverviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
