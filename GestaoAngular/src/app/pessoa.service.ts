import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Pessoa } from './Pessoa';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
    })
};

@Injectable({
  providedIn: 'root'
})

export class PessoaService {
  url = 'http://localhost:5246/api/pessoa';
  constructor(private http: HttpClient) { }

  GetPessoas(): Observable<Pessoa[]>{
      return this.http.get<Pessoa[]>(this.url);
  }

  GetPessoa(pessoaId: number): Observable<Pessoa>{
    const apiUrl = `${this.url}/${pessoaId}`;
    return this.http.get<Pessoa>(apiUrl);
  }

  SalvarPessoa(pessoa: Pessoa): Observable<any>{
    return this.http.post<Pessoa>(this.url, pessoa, httpOptions)
  }

  AtualizarPessoa(pessoa: Pessoa) : Observable<Pessoa>{
    return this.http.put<Pessoa>(this.url, pessoa, httpOptions);
  }

  ExcluirPessoa(pessoaId : number) : Observable<any>{
    const apiUrl = `${this.url}/${pessoaId}`;
    return this.http.delete<number>(apiUrl, httpOptions);
  }
}
