import { ResponseModel } from './../models/response-model';
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { throwError } from 'rxjs';
import { environment } from 'src/enviroments/environment';

@Injectable({
  providedIn: 'root'
})
export class HttpclientService {

  constructor(private _http: HttpClient) { }


  Post(endpoint: string, typeEndPoint:string, value:any): Promise<object> {
    let response = this._http.post(`${environment.backend}${endpoint}/${typeEndPoint}`, value)
        .toPromise()
        .then(result => result as ResponseModel)
        .catch(this.handleError);
    return response;
}

getAll(endpoint: string, typeEndPoint:string): Promise<object> {
  let response = this._http.get(`${environment.backend}${endpoint}/${typeEndPoint}`)
      .toPromise()
      .then(result => result as ResponseModel)
      .catch(this.handleError);
  return response;
}


private handleError(error: HttpErrorResponse) {
  if (error.error instanceof ErrorEvent) {
      // Ocurre un error al lado del cliente o error de red
      console.error('Ocurrio un error:', error.error.message);
  } else {
      // El Api retorna respuesta no satisfactoria.
      // El cuerpo de la respueta puede contener algo que indique el error.
      console.error(
          `Api retorna codigo ${error.status}, ` +
          `con cuerpo: ${error.message}`);
  }
  // retorna un observable con mensaje de error
  return throwError(
      'Algo ha sucedio un error; favor intentarlo de nuevo más tarde.');
}

}
