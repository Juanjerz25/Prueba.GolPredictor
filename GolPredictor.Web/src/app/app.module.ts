import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { InicioComponent } from './inicio/inicio.component';
import { SesionActivaComponent } from './sesion-activa/sesion-activa.component';
import { HeaderPrincipalComponent } from './header-principal/header-principal.component';

@NgModule({
  declarations: [
    AppComponent,
    InicioComponent,
    SesionActivaComponent,
    HeaderPrincipalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
