import { Injectable, inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PagedResult } from '../models/paged-result.model';
import { EstudianteDto } from '../models/estudianteDto.model';
import { ReporteDataDto } from '../models/reporteDataDto.model';
import { forkJoin, of } from 'rxjs';
import { switchMap, catchError } from 'rxjs/operators';
import { CursoService } from './curso.service';
import { ProvinciaService } from './provincia.service';

@Injectable({ providedIn: 'root' })
export class EstudianteService {
  private http = inject(HttpClient);
  private cursoService = inject(CursoService);
  private provinciaService = inject(ProvinciaService);
  private apiUrl = 'http://localhost:5141/api/estudiantes';

  getEstudiantesPorProvincia(idProvincia: number, page: number, size: number): Observable<PagedResult<EstudianteDto>> {
    const params = new HttpParams()
      .set('pageNumber', page.toString())
      .set('pageSize', size.toString());

    return this.http.get<PagedResult<EstudianteDto>>(`${this.apiUrl}/provincia/${idProvincia}`, { params });
  }

  getListadoEstudiantes(idProvincia: number, page: number, size: number): Observable<any> {
    const params = new HttpParams()
      .set('pageNumber', page.toString())
      .set('pageSize', size.toString());
      
    // Usamos forkJoin para realizar dos peticiones simultaneas
    return forkJoin({
      provincias: this.provinciaService.getProvincias(),
      estudiantes: this.http.get<PagedResult<EstudianteDto>>(`${this.apiUrl}/provincia/${idProvincia}`, { params })
    });
  }

  crearEstudiante(estudiante: any): Observable<number> {
    return this.http.post<number>(this.apiUrl, estudiante);
  }

  getReporteJerarquico(): Observable<ReporteDataDto[]> {
    return this.http.get<ReporteDataDto[]>(`${this.apiUrl}/reporte-jerarquico`)
  }

  getDetallePopularPorCurso(idCurso: number): Observable<any> {
    /* Usamos switchMap para evitar que los datos se pisen en caso de que el usuario
       realice la misma llamada con distinto valor antes de que la primera termine*/
    return this.http.get<any>(`${this.apiUrl}/curso/${idCurso}`).pipe(
      switchMap(curso => {
        return this.http.get(`${this.apiUrl}/curso/${curso.id}/provincia-popular`);
      }),
      catchError(err => {
        console.error('Se ha producido un error', err);
        return of(null);
      })
    );
  }

}