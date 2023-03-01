import { SesionUsuarioDto } from './../../core/models/sesion-usuario-dto';
import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { EndPoints } from 'src/app/const/endPoints.enum';
import { TypeEndPoints } from 'src/app/const/type-endpoints.enum';
import { PartidoDto } from 'src/app/core/models/partido-dto';
import { ResponseModel } from 'src/app/core/models/response-model';
import { SesionDto } from 'src/app/core/models/sesion-dto';
import { AlertService } from 'src/app/core/services/alert.service';
import { HttpclientService } from 'src/app/core/services/httpclient.service';

@Component({
  selector: 'app-agregar-sesion',
  templateUrl: './agregar-sesion.component.html',
  styleUrls: ['./agregar-sesion.component.css'],
})
export class AgregarSesionComponent implements OnInit {
  formSesion: FormGroup;
  partidos: PartidoDto[] = [];

  constructor(
    private dialogRef: MatDialogRef<AgregarSesionComponent>,
    private service: HttpclientService,
    private alertService: AlertService
  ) {
    this.formSesion = new FormGroup({
      nombre: new FormControl('', [Validators.required]),
      partidoId: new FormControl('', [Validators.required]),
    });
  }

  async ngOnInit() {
    await this.getPartidos();
  }

  async getPartidos() {
    let response = (await this.service.getAll(
      EndPoints.Partido,
      TypeEndPoints.GetPartidos
    )) as ResponseModel;
    if (response.successful) {
      this.partidos = response.result;
    } else {
      this.alertService.error(response.errorMessage);
    }
  }

  async submit() {
    let sesion = {
      id: 0,
      nombre: this.formSesion.value.nombre,
      partidoId: this.formSesion.value.partidoId,
      entryCode: '',
      status: true,
      sesionUsuario: null,
      partido:null
    } as  SesionDto;

    let response = (await this.service.Post(
      EndPoints.Sesion,
      TypeEndPoints.ManageSesion,
      sesion
    )) as ResponseModel;
    if (response.successful) {
      this.alertService.success('Registro guardado exitosamente');
      this.dialogRef.close(response.result);
    } else {
      this.alertService.error(response.message);
    }
  }

  hasError = (controlName: string, errorName: string) => {
    return this.formSesion.controls[controlName].hasError(errorName);
  };
}
