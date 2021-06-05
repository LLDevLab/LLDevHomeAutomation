import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SensorSelectionComponent } from './sensor-selection.component';

describe('SensorSelectionComponent', () => {
  let component: SensorSelectionComponent;
  let fixture: ComponentFixture<SensorSelectionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SensorSelectionComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SensorSelectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
