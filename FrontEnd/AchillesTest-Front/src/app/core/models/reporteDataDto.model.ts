export interface ReporteDataDto {
  docente: string;
  cursos: {
    curso: string;
    provincias: {
      provincia: string;
      alumnos: string[];
    }[];
  }[];
}