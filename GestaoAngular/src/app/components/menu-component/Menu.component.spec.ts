/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { MenuComponent } from './Menu.component';

describe('MenuComponent', () => {
  let component: MenuComponent;
  let fixture: ComponentFixture<MenuComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MenuComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should toggle isOpen', () => {
    component.toggle();
    expect(component.isOpen).toBeTrue();
    component.toggle();
    expect(component.isOpen).toBeFalse();
  });

  it('should log the correct page', () => {
    spyOn(console, 'log');
    component.openPage('home');
    expect(console.log).toHaveBeenCalledWith('Opening page: home');
  });
});
