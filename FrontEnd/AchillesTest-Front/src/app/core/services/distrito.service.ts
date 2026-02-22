import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { DistritoDto } from '../models/distritoDto.model';

@Injectable({
  providedIn: 'root'
})
export class DistritoService {
  private http = inject(HttpClient);
  private url = 'http://localhost:5141/api/distritos';

  getDistritos(): Observable<DistritoDto[]> {
    return this.http.get<DistritoDto[]>(this.url);
  }
}