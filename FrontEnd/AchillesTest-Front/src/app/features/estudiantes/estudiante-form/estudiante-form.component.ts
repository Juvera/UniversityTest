import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DistritoService } from '../../../core/services/distrito.service';
import { EstudianteService } from '../../../core/services/estudiante.service';
import { DistritoDto } from '../../../core/models/distritoDto.model';

@Component({
  selector: 'app-estudiante-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './estudiante-form.component.html'
})
export class EstudianteFormComponent implements OnInit {
  private fb = inject(FormBuilder);
  private distritoService = inject(DistritoService);
  private estudianteService = inject(EstudianteService);
  private router = inject(Router);

  distritos: DistritoDto[] = [];

  // Definimos el formulario con validaciones
  form = this.fb.group({
    nomb_est: ['', [Validators.required, Validators.minLength(3)]],
    apel_est: ['', [Validators.required]],
    idDistrito: [null, [Validators.required]]
  });

  ngOnInit() {
    this.distritoService.getDistritos().subscribe({
      next: (data) => this.distritos = data,
      error: (e) => console.error('Error al cargar distritos', e)
    });
  }

  guardar() {
    if (this.form.invalid) return;

    this.estudianteService.crearEstudiante(this.form.value).subscribe({
      next: () => {
        alert('Estudiante creado con éxito');
        this.router.navigate(['/estudiantes']);
      },
      error: (err) => alert('Error al crear: ' + err.message)
    });
  }
}