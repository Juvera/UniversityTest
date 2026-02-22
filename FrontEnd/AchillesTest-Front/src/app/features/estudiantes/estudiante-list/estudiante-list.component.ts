import { Component, OnInit, inject } from '@angular/core';
import { EstudianteService } from '../../../core/services/estudiante.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PagedResult } from '../../../core/models/paged-result.model';
import { EstudianteDto } from '../../../core/models/estudianteDto.model';
import { ProvinciaService } from '../../../core/services/provincia.service';
import { ProvinciaDto } from '../../../core/models/provinciaDto.model';

@Component({
  selector: 'app-estudiante-list',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './estudiante-list.component.html'
})
export class EstudianteListComponent implements OnInit {
  private estudianteService = inject(EstudianteService);
  
  datosPaginados?: PagedResult<EstudianteDto>;
  provincias: ProvinciaDto[] = [];
  
  paginaActual = 1;
  pageSize = 10;
  idProvinciaSeleccionada = 1; 

  ngOnInit() {
    this.cargaListadoInicial();
    this.cargarEstudiantes();
  }

  cargaListadoInicial() {
    this.estudianteService.getListadoEstudiantes(this.idProvinciaSeleccionada, this.paginaActual, this.pageSize).subscribe({
      next: (data) => {
        this.provincias = data.provincias;
        this.datosPaginados = data.cursos;
      },
      error: (err) => {
        console.error('Error al obtener los datos:', err);
      }
    });
  }

  onProvinciaChange(id: string) {
    this.idProvinciaSeleccionada = Number(id);
    this.paginaActual = 1;
    this.cargarEstudiantes();
  }

  cargarEstudiantes() {
    this.estudianteService.getEstudiantesPorProvincia(this.idProvinciaSeleccionada, this.paginaActual, this.pageSize)
      .subscribe({
        next: (res) => this.datosPaginados = res,
        error: (err) => console.error('Se ha producido un error:', err)
      });
  }

  cambiarPagina(nuevaPagina: number) {
    this.paginaActual = nuevaPagina;
    this.cargarEstudiantes();
  }
}