import { AgregarSesionComponent } from './../agregar-sesion/agregar-sesion/agregar-sesion.component';
import { Component, ElementRef, OnDestroy, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { dialogConfig } from '../const/dialog-config';
import { EndPoints } from '../const/endPoints.enum';
import { TypeEndPoints } from '../const/type-endpoints.enum';
import { ResponseModel } from '../core/models/response-model';
import { SesionDto } from '../core/models/sesion-dto';
import { AlertService } from '../core/services/alert.service';
import { HttpclientService } from '../core/services/httpclient.service';
import { WebsocketService } from '../core/services/websocket.service';
import { Observable, Subscription } from 'rxjs';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';

@Component({
  selector: 'app-sesion-activa',
  templateUrl: './sesion-activa.component.html',
  styleUrls: ['./sesion-activa.component.css'],
  providers: [HttpclientService, WebsocketService],
})
export class SesionActivaComponent implements OnInit,OnDestroy {
  sesionColumns: string[] = ['nombre', 'usersQuantity', 'startDate'];
  dataSource: MatTableDataSource<SesionDto>;
  response: ResponseModel = {};
  private datosSubscription: Subscription;
  transactions$: Observable<number>;

  constructor(
    private service: HttpclientService,
    private alertService: AlertService,
    public dialog: MatDialog,
    private websocketService: WebsocketService,
    private el: ElementRef
  ) {
    this.websocketService.connect('SesionesActivas');

    this.datosSubscription = this.websocketService.data$.subscribe(
      (data) => {

        this.dataSource = data;
        console.log(this.dataSource);
      }
    );

  }

  ngOnInit() {
    //await this.getSesionList();
  }

  ngOnDestroy(): void {
      this.websocketService.close();
  }

  async getSesionList() {
    let response = (await this.service.getAll(
      EndPoints.Sesion,
      TypeEndPoints.GetSesiones
    )) as ResponseModel;
    if (response.successful) {
      this.dataSource = response.result;
    } else {
      this.alertService.error(response.errorMessage);
    }
  }

  async addSesion() {
    const dialogRef: MatDialogRef<AgregarSesionComponent, string> =
      this.dialog.open(AgregarSesionComponent, dialogConfig);
    dialogRef.afterClosed().subscribe((result) => {
      this.getSesionList();
    });
  }


}
