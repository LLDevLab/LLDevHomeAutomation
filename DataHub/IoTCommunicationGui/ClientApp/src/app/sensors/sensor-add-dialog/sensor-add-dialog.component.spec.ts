import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SensorAddDialogComponent } from './sensor-add-dialog.component';

describe('SensorAddDialogComponent', () => {
  let component: SensorAddDialogComponent;
  let fixture: ComponentFixture<SensorAddDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SensorAddDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SensorAddDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
