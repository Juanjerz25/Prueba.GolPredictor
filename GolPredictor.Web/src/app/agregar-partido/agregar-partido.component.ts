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
@Component({
  selector: 'app-agregar-partido',
  templateUrl: './agregar-partido.component.html',
  styleUrls: ['./agregar-partido.component.css'],
  providers: [HttpclientService],
})
export class AgregarPartidoComponent implements OnInit {
  formPartido: FormGroup;

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
    });
  }
  ngOnInit() {
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
      });
    }
  }
}
