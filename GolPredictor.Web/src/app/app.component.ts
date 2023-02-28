import { Component } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { dialogConfig } from './const/dialog-config';
import { InicioSesionComponent } from './inicio-sesion/inicio-sesion.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'golpredictor';
  isLogIn: Boolean = false;

  constructor(public dialog: MatDialog) {}

  openDialog() {
    const dialogRef: MatDialogRef<InicioSesionComponent, string> =
      this.dialog.open(InicioSesionComponent, dialogConfig);

    dialogRef.afterClosed().subscribe((result) => {
      // validacion
      if (result != undefined && result != null) {
        this.isLogIn = true;
      }
    });
  }
}
