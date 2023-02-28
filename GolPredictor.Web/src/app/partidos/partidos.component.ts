import { PartidoDto } from './../core/models/partido-dto';
import { Component, OnInit } from '@angular/core';
import { HttpclientService } from '../core/services/httpclient.service';
import { ResponseModel } from '../core/models/response-model';
import { EndPoints } from '../const/endPoints.enum';
import { TypeEndPoints } from '../const/type-endpoints.enum';
import { AlertService } from '../core/services/alert.service';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { dialogConfig } from '../const/dialog-config';
import { AgregarPartidoComponent } from '../agregar-partido/agregar-partido.component';

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}
@Component({
  selector: 'app-partidos',
  templateUrl: './partidos.component.html',
  styleUrls: ['./partidos.component.css'],
  providers: [HttpclientService]
})
export class PartidosComponent implements OnInit {
  partidoColumns: string[] = ['Team1', 'Team2', 'FechaInicio', 'ResultTeam1', 'ResultTeam2', 'Status'];
  dataSource: PartidoDto[] = [];
  clickedRows = new Set<PeriodicElement>();

  partidos: PartidoDto[] = [];
  response: ResponseModel = {};
  constructor(
    private service: HttpclientService,
    private alertService: AlertService,
    public dialog: MatDialog
  ) {}

  async ngOnInit() {
    await this.getPartidosList();
  }

  async getPartidosList() {
    this.response = await this.service.getAll(
      EndPoints.Partido,
      TypeEndPoints.GetPartidos
    );
    if (this.response.successful) {
      this.dataSource = this.response.result as PartidoDto[];
    } else {
      this.alertService.error(this.response.errorMessage);
    }
  }

  async popUpPartido(partido:any){
    dialogConfig.data = partido;

    const dialogRef: MatDialogRef<AgregarPartidoComponent, string> =
      this.dialog.open(AgregarPartidoComponent, dialogConfig);
      dialogRef.afterClosed().subscribe((result) => {
          this.getPartidosList();
      });

  }

}
