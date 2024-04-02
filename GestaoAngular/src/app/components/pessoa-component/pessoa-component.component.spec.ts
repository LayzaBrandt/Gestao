import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PessoaComponent } from './pessoa-component.component';

describe('PessoaComponent', () => {
  let component: PessoaComponent;
  let fixture: ComponentFixture<PessoaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PessoaComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PessoaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
