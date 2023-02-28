import { PartidoDto } from './../core/models/partido-dto';
import { Component, OnInit } from '@angular/core';
import { HttpclientService } from '../core/services/httpclient.service';
import { ResponseModel } from '../core/models/response-model';
import { EndPoints } from '../const/endPoints.enum';
import { TypeEndPoints } from '../const/type-endpoints.enum';
import { AlertService } from '../core/services/alert.service';

export interface PeriodicElement {
  name: string;
  position: number;
  weight: number;
  symbol: string;
}

const ELEMENT_DATA: PeriodicElement[] = [
  { position: 1, name: 'Hydrogen', weight: 1.0079, symbol: 'H' },
  { position: 2, name: 'Helium', weight: 4.0026, symbol: 'He' },
  { position: 3, name: 'Lithium', weight: 6.941, symbol: 'Li' },
  { position: 4, name: 'Beryllium', weight: 9.0122, symbol: 'Be' },
  { position: 5, name: 'Boron', weight: 10.811, symbol: 'B' },
  { position: 6, name: 'Carbon', weight: 12.0107, symbol: 'C' },
  { position: 7, name: 'Nitrogen', weight: 14.0067, symbol: 'N' },
  { position: 8, name: 'Oxygen', weight: 15.9994, symbol: 'O' },
  { position: 9, name: 'Fluorine', weight: 18.9984, symbol: 'F' },
  { position: 10, name: 'Neon', weight: 20.1797, symbol: 'Ne' },
];

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
    private alertService: AlertService
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
}
