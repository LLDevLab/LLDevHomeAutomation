import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SensorEventAddDialogComponent } from './sensor-event-add-dialog.component';

describe('SensorEventAddDialogComponent', () => {
  let component: SensorEventAddDialogComponent;
  let fixture: ComponentFixture<SensorEventAddDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SensorEventAddDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SensorEventAddDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
