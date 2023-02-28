import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { InicioComponent } from './inicio/inicio.component';
import { SesionActivaComponent } from './sesion-activa/sesion-activa.component';
import { HeaderPrincipalComponent } from './header-principal/header-principal.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PartidosComponent } from './partidos/partidos.component';
import { InicioSesionComponent } from './inicio-sesion/inicio-sesion.component';
import { MatDialogModule } from '@angular/material/dialog';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { SweetAlert2Module } from '@sweetalert2/ngx-sweetalert2';
import { HttpClientModule } from '@angular/common/http';
import { MatTableModule } from '@angular/material/table';
import { AgregarPartidoComponent } from './agregar-partido/agregar-partido.component';

@NgModule({
  declarations: [
    AppComponent,
    InicioComponent,
    SesionActivaComponent,
    HeaderPrincipalComponent,
    PartidosComponent,
    InicioSesionComponent,
    AgregarPartidoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatDialogModule,
    FormsModule,
    ReactiveFormsModule,
    MatCardModule,
    MatInputModule,
    MatButtonModule,
    HttpClientModule,
    SweetAlert2Module.forRoot(),
    MatTableModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
