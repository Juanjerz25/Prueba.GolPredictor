import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { InicioComponent } from './inicio/inicio.component';
import { SesionActivaComponent } from './sesion-activa/sesion-activa.component';
import { HeaderPrincipalComponent } from './header-principal/header-principal.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PartidosComponent } from './partidos/partidos.component';

@NgModule({
  declarations: [
    AppComponent,
    InicioComponent,
    SesionActivaComponent,
    HeaderPrincipalComponent,
    PartidosComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
