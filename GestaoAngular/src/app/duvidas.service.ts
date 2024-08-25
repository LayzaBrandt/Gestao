import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class DuvidasService {
  url = 'http://localhost:5246/api/duvidas';
constructor(private http: HttpClient) {
 }
}
