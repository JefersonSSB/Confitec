import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar'
import { HttpClient } from '@angular/common/http';
import { Schooling } from '../models/schooling.model'
import { Observable, EMPTY } from 'rxjs';
import { map, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class SchoolingService {

  baseUrl = "https://localhost:44360/v1/escolaridade";

  constructor(private snackBar: MatSnackBar, private http: HttpClient) { }

  showMessage(msg: string, isError: boolean = false): void {
    this.snackBar.open(msg, 'X', {
      duration: 3000,
      horizontalPosition: "center",
      verticalPosition: "bottom",
      panelClass: isError ? ['msg-error'] : ['msg-success']

    })
  }

  get(): Observable<Schooling[]> {
    return this.http.get<Schooling[]>(this.baseUrl).pipe(
      map(obj => obj),
      catchError(e => this.errorHandler(e))
    );
  }

  errorHandler(e: any): Observable<any> {
    this.showMessage("Ocorreu um erro!", true)
    return EMPTY;
  }
}