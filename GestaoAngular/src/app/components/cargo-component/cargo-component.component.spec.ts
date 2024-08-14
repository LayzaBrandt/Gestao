import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CargoComponent } from './cargo-component.component';

describe('CargoComponentComponent', () => {
  let component: CargoComponent;
  let fixture: ComponentFixture<CargoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CargoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CargoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
