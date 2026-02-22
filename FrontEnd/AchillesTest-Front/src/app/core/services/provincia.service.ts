import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { ProvinciaDto } from '../models/provinciaDto.model';

@Injectable({
  providedIn: 'root'
})
export class ProvinciaService {
  private http = inject(HttpClient);
  private url = 'http://localhost:5141/api/provincias';

  getProvincias(): Observable<ProvinciaDto[]> {
    return this.http.get<ProvinciaDto[]>(this.url);
  }
}