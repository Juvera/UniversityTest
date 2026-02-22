import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EstudianteService } from '../../core/services/estudiante.service';
import { ReporteDataDto } from '../../core/models/reporteDataDto.model';
import { CursoDto } from '../../core/models/cursoDto.model';

@Component({
  selector: 'app-reporte-jerarquico',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './reporte-jerarquico.component.html'
})
export class ReporteJerarquicoComponent implements OnInit {
  private estudianteService = inject(EstudianteService);
  
  reporteData: ReporteDataDto[] = [];
  loading = true;

  ngOnInit() {
    this.estudianteService.getReporteJerarquico().subscribe({
      next: (data) => {
        this.reporteData = data;
        this.loading = false;
      },
      error: (err) => {
        console.error('Error al obtener los datos:', err);
        this.loading = false;
      }
    });
  }
}