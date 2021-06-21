import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SensorEditDialogComponent } from './sensor-edit-dialog.component';

describe('SensorEditDialogComponent', () => {
  let component: SensorEditDialogComponent;
  let fixture: ComponentFixture<SensorEditDialogComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SensorEditDialogComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SensorEditDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
