import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AgregarSesionComponent } from './agregar-sesion.component';

describe('AgregarSesionComponent', () => {
  let component: AgregarSesionComponent;
  let fixture: ComponentFixture<AgregarSesionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AgregarSesionComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AgregarSesionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
