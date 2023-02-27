import { Injectable } from '@angular/core';
import { SweetAlertIcon } from 'sweetalert2';
import Swal from 'sweetalert2/dist/sweetalert2.js';
@Injectable({
  providedIn: 'root'
})
export class AlertService {

  constructor() { }


  private alert(text: string,icon:SweetAlertIcon,iconColor:string) {
    return Swal.fire({
        title: '',
        text:text,
        icon: icon,
        iconColor: iconColor,
        confirmButtonText: 'Aceptar',
        confirmButtonColor: '#5C88DA',
        allowOutsideClick: false,
        allowEscapeKey: false
    });
  }
  success(text: string = 'Proceso realizado con éxito.'){
    return this.alert(text, 'success', '#BAD405');
  }

  error(text: string = 'Error en el proceso.'){
    return this.alert(text, 'error', '#D22D4B');
  }

  warning(text: string = 'Proceso realizado con éxito.'){
    return this.alert(text, 'warning', '#FFBC42');
  }



}

