import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'estudiantes',
    pathMatch: 'full'
  },
  {
    path: 'estudiantes',
    loadComponent: () => import('./features/estudiantes/estudiante-list/estudiante-list.component')
      .then(m => m.EstudianteListComponent)
  },
  {
    path: 'estudiantes/nuevo',
    loadComponent: () => import('./features/estudiantes/estudiante-form/estudiante-form.component')
      .then(m => m.EstudianteFormComponent)
  },
  {
    path: 'reporte',
    loadComponent: () => import('./features/reporte-jerarquico/reporte-jerarquico.component')
      .then(m => m.ReporteJerarquicoComponent)
  },
  {
    path: '**',
    redirectTo: 'estudiantes'
  }
];