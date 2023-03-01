import { PaisDto } from './../core/models/pais-dto';
import { PartidoDto } from './../core/models/partido-dto';
import { TypeEndPoints } from './../const/type-endpoints.enum';
import { EndPoints } from './../const/endPoints.enum';

import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { HttpclientService } from 'src/app/core/services/httpclient.service';
import { RequestLoginDto } from '../core/models/request-log-in';
import { ResponseModel } from '../core/models/response-model';
import { AlertService } from '../core/services/alert.service';
import { MatCalendarCellClassFunction } from '@angular/material/datepicker';
import { DatePipe } from '@angular/common';
@Component({
  selector: 'app-agregar-partido',
  templateUrl: './agregar-partido.component.html',
  styleUrls: ['./agregar-partido.component.css'],
  providers: [HttpclientService],
})
export class AgregarPartidoComponent implements OnInit {
  formPartido: FormGroup;
  paisList: PaisDto[] = [];

  dateClass: MatCalendarCellClassFunction<Date> = (cellDate, view) => {
    // Only highligh dates inside the month view.
    if (view === 'month') {
      const date = new Date();

      if (
        cellDate.getFullYear() === date.getFullYear() &&
        cellDate.getMonth() === date.getMonth() &&
        cellDate.getDate() === date.getDate()
      ) {
        return 'mark-day';
      } else {
        return '';
      }
    }

    return '';
  };

  constructor(
    private dialogRef: MatDialogRef<AgregarPartidoComponent>,
    private service: HttpclientService,
    private alertService: AlertService,
    @Inject(MAT_DIALOG_DATA) public partidoInject: PartidoDto
  ) {
    this.formPartido = new FormGroup({
      team1Id: new FormControl('', [Validators.required]),
      team2Id: new FormControl('', [Validators.required]),
      resultTeam1: new FormControl(0, [Validators.required]),
      resultTeam2: new FormControl(0, [Validators.required]),
      fechaInicio: new FormControl('', [Validators.required]),
      status: new FormControl(true),
    });
  }
  async ngOnInit() {
    await this.getPaises();
    if (this.partidoInject !== null) {
      this.formPartido = new FormGroup({
        team1Id: new FormControl(this.partidoInject.team1Id, [
          Validators.required,
        ]),
        team2Id: new FormControl(this.partidoInject.team2Id, [
          Validators.required,
        ]),
        resultTeam1: new FormControl(this.partidoInject.resultTeam1, [
          Validators.required,
        ]),
        resultTeam2: new FormControl(this.partidoInject.resultTeam2, [
          Validators.required,
        ]),
        fechaInicio: new FormControl(this.partidoInject.fechaInicio, [
          Validators.required,
        ]),
        status: new FormControl(this.partidoInject.status),
      });
    }
  }

  async getPaises() {
    let response = (await this.service.getAll(
      EndPoints.Pais,
      TypeEndPoints.GetPaises
    )) as ResponseModel;
    if (response.successful) {
      console.log(response);
      this.paisList = response.result;
    } else {
      this.alertService.error(response.errorMessage);
    }
  }

  async submit() {
    console.log((this.formPartido.value.fechaInicio));
    let partido = {
      id: this.partidoInject !== null ? this.partidoInject.id : 0,
      team1Id: this.formPartido.value.team1Id,
      team2Id: this.formPartido.value.team2Id,
      resultTeam1: this.formPartido.value.resultTeam1,
      resultTeam2: this.formPartido.value.resultTeam2,
      fechaInicio: this.formPartido.value.fechaInicio,
      status: this.formPartido.value.status,
    } as any;

    let response = (await this.service.Post(
      EndPoints.Partido,
      TypeEndPoints.ManagePartido,
      partido
    )) as ResponseModel;
    if (response.successful) {
      this.alertService.success('Registro guardado exitosamente');
      this.dialogRef.close(response.successful);
    } else {
      this.alertService.error(response.message);
    }
  }

  hasError = (controlName: string, errorName: string) => {
    return this.formPartido.controls[controlName].hasError(errorName);
  };


}

function DateFormat(date_Object: Date): string {
  // get the year, month, date, hours, and minutes seprately and append to the string.
  let date_String: string =
    date_Object.getDate() +
    "/" +
    (date_Object.getMonth() + 1) +
    "/" +
    +date_Object.getFullYear() +
    "  " +
    +date_Object.getHours().toString().padStart(2, '0') +
    ":" +
    +date_Object.getMinutes()+":00";
  return date_String;
}
