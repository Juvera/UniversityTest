import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { CursoDto } from '../models/cursoDto.model';

@Injectable({
  providedIn: 'root'
})
export class CursoService {
  private http = inject(HttpClient);
  private url = 'http://localhost:5141/api/cursos';

  getCursos(): Observable<CursoDto[]> {
    return this.http.get<CursoDto[]>(this.url);
  }
}