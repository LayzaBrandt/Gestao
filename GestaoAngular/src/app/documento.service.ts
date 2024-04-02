import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Documento } from './Documento';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class DocumentoService {
  url = 'http://localhost:5246/api/documentoCartaOficialDesligamento'; 

  constructor(private http: HttpClient) { }

  GetDocumentos(): Observable<Documento[]> {
    return this.http.get<Documento[]>(this.url);
  }

  GetDocumento(documentoId: number): Observable<Documento> {
    const apiUrl = `${this.url}/${documentoId}`;
    return this.http.get<Documento>(apiUrl);
  }

  SalvarDocumento(documento: Documento): Observable<any> {
    return this.http.post<Documento>(this.url, documento, httpOptions);
  }

  AtualizarDocumento(documento: Documento): Observable<Documento> {
    return this.http.put<Documento>(this.url, documento, httpOptions);
  }

  ExcluirDocumento(documentoId: number): Observable<any> {
    const apiUrl = `${this.url}/${documentoId}`;
    return this.http.delete<any>(apiUrl, httpOptions);
  }
}
