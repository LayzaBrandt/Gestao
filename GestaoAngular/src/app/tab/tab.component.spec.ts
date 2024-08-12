import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TabComponent } from './tab.component';

describe('TabComponent', () => {
  let component: TabComponent;
  let fixture: ComponentFixture<TabComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TabComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TabComponent);
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
