import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cargo } from './Cargo';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class CargoService {
  url = 'http://localhost:5246/api/cargo';

  constructor(private http: HttpClient) { }

  GetCargos(): Observable<Cargo[]> {
    return this.http.get<Cargo[]>(this.url);
  }

  GetCargo(cargoId: number): Observable<Cargo> {
    const apiUrl = `${this.url}/${cargoId}`;
    return this.http.get<Cargo>(apiUrl);
  }

  SalvarCargo(cargo: Cargo): Observable<any> {
    return this.http.post<Cargo>(this.url, cargo, httpOptions);
  }

  AtualizarCargo(cargo: Cargo): Observable<Cargo> {
    return this.http.put<Cargo>(this.url, cargo, httpOptions);
  }

  ExcluirCargo(cargoId: number): Observable<any> {
    const apiUrl = `${this.url}/${cargoId}`;
    return this.http.delete<any>(apiUrl, httpOptions);
  }
}
