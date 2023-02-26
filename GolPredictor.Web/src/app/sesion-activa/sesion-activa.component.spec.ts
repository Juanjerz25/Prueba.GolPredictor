import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SesionActivaComponent } from './sesion-activa.component';

describe('SesionActivaComponent', () => {
  let component: SesionActivaComponent;
  let fixture: ComponentFixture<SesionActivaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SesionActivaComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SesionActivaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
