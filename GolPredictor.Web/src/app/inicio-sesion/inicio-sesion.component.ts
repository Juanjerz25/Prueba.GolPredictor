import { TypeEndPoints } from './../const/type-endpoints.enum';
import { EndPoints } from './../const/endPoints.enum';

import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { HttpclientService } from 'src/app/core/services/httpclient.service';
import { RequestLoginDto } from '../core/models/request-log-in';
import { ResponseModel } from '../core/models/response-model';
import { AlertService } from '../core/services/alert.service';

@Component({
  selector: 'app-inicio-sesion',
  templateUrl: './inicio-sesion.component.html',
  styleUrls: ['./inicio-sesion.component.css'],
  providers: [HttpclientService]
})
export class InicioSesionComponent implements OnInit{
  formInicioSesion: FormGroup;
  response: ResponseModel;

  constructor(
    private dialogRef: MatDialogRef<InicioSesionComponent>,
    private service: HttpclientService,
    private alertService: AlertService
  ) {
    this.formInicioSesion = new FormGroup({
      nombre: new FormControl('', [Validators.required]),
      contrasena: new FormControl('', [Validators.required]),
    });

    this.response = {} as ResponseModel;
  }
  ngOnInit(): void {
    this.formInicioSesion = new FormGroup({
      nombre: new FormControl('', [Validators.required]),
      contrasena: new FormControl('', [Validators.required]),
    });
  }

  async LogIn() {
    let loginUser = {
      nombre: this.formInicioSesion.value.nombre,
      contrasena: this.formInicioSesion.value.contrasena,
    } as RequestLoginDto;

    this.response = await this.service.Post(
      EndPoints.UserAdmin,
      TypeEndPoints.LogIn,
      loginUser
    );
    if(this.response.successful){
      this.dialogRef.close(this.response.successful);
    }
    else{
      this.alertService.error(this.response.message);
    }


  }

  hasError = (controlName: string, errorName: string) => {
    return this.formInicioSesion.controls[controlName].hasError(errorName);
  };
}
