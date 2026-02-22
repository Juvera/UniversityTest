using AchillesTest.Application.DTOs;
using AchillesTest.Application.Interfaces;
using AchillesTest.Domain.Entities;
using AchillesTest.Domain.StoreProcedure;
using AchillesTest.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AchillesTest.Application.Service
{
    public class EstudianteService : IEstudianteService
    {
        private readonly UniversidadDbContext _context;

        public EstudianteService(UniversidadDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene una lista de estadísticas por provincia, 
        /// donde cada elemento contiene el nombre de la provincia y 
        /// la cantidad de estudiantes asociados a esa provincia.
        /// </summary>
        /// <param name="pageNumber">posicion de la paginación</param>
        /// <param name="pageSize">Tamaño de la paginación</param>
        /// <returns></returns>
        public async Task<PagedResult<EstadisticasProvinciasDto>> GetEstadisticasProvincias(int pageNumber, int pageSize)
        {
            // Realizamos la consulta base para obtener las provincias
            var query = _context.TB_PROVINCIA.AsNoTracking();

            // Obtenemos el total de registros para la paginación
            var totalCount = await query.CountAsync();

            // Aplicamos la paginación a la consulta y proyectamos los resultados a EstadisticasProvinciasDto
            var items = await query
                .Skip((pageNumber - 1) * pageSize) // Saltamos los registros de páginas anteriores
                .Take(pageSize)                    // Tomamos solo la cantidad solicitada
                .Select(p => new EstadisticasProvinciasDto(
                    p.Nomb_pro,
                    p.Distritos.SelectMany(d => d.Estudiantes).Count()
                ))
                .ToListAsync();

            return new PagedResult<EstadisticasProvinciasDto>(items, totalCount, pageNumber, pageSize);
        }


        /// <summary>
        /// Obtiene la provincia más popular para un curso específico 
        /// utilizando un procedimiento almacenado.
        /// </summary>
        /// <param name="idCurso">Identificador del curso</param>
        /// <returns></returns>
        public async Task<ProvinciaPopularResult?> ObtenerProvinciaPopularPorCurso(int idCurso)
        {
            var query = await _context.ProvinciaPopularResults
                .FromSqlInterpolated($"EXEC sp_GetProvinciaMasPopularPorCurso @idcurso = {idCurso}") // Ejecutamos el procedimiento almacenado con el parámetro del curso
                .ToListAsync();

            return query.FirstOrDefault();
        }

        /// <summary>
        /// Inserta un nuevo estudiante en la base de datos y devuelve su ID generado. 
        /// El método agrega el estudiante al contexto, guarda los cambios y retorna el ID del nuevo estudiante.
        /// </summary>
        /// <param name="estudiante">Estudiante a insertar en la BBDD</param>
        /// <returns></returns>
        public async Task<int> InsertarEstudiante(Estudiante estudiante)
        {
            // Agregamos el nuevo estudiante al contexto
            _context.TB_ESTUDIANTE.Add(estudiante);

            // Guardamos los cambios en la base de datos
            await _context.SaveChangesAsync();

            return estudiante.IdEstudiante;
        }


        /// <summary>
        /// Obtiene una lista de estudiantes que pertenecen a una provincia específica.
        /// </summary>
        /// <param name="idProvincia">Identificador de la provincia</param>
        /// <param name="pageNumber">posicion de la paginación</param>
        /// <param name="pageSize">Tamaño de la paginación</param>
        /// <returns></returns>
        public async Task<PagedResult<EstudianteDto>> ObtenerPorProvincia(int idProvincia, int pageNumber, int pageSize)
        {
            // Realizamos la consulta base para obtener los estudiantes de la provincia especificada
            var query = _context.TB_ESTUDIANTE
                .AsNoTracking()
                .Where(e => e.Distrito!.Idprovincia == idProvincia);

            // Obtenemos el total de registros para la paginación
            var totalCount = await query.CountAsync();

            // Aplicamos la paginación a la consulta y proyectamos los resultados a EstudianteDto
            var items = await query
                .Skip((pageNumber - 1) * pageSize) // Saltamos los registros de páginas anteriores
                .Take(pageSize)                    // Tomamos solo la cantidad solicitada
                .Select(e => new EstudianteDto(
                    e.Nomb_est,
                    e.Apel_est,
                    e.Distrito!.Provincia!.Nomb_pro
                ))
                .ToListAsync();

            return new PagedResult<EstudianteDto>(items, totalCount, pageNumber, pageSize);
        }

        /// <summary>
        /// Obtiene un reporte jerárquico de docentes, sus cursos y los estudiantes 
        /// matriculados en cada curso agrupados por provincia.
        /// </summary>
        /// <returns></returns>
        public async Task<List<ReporteDocenteDto>> GetReporteJerarquico()
        {
            return await _context.TB_DOCENTE
                .AsNoTracking()
                .AsSplitQuery() // Indicamos que queremos usar consultas separadas para evitar problemas de rendimiento con múltiples niveles de relaciones
                .Select(d => new ReporteDocenteDto(
                    d.Nomb_doc + " " + d.Apel_doc,
                    d.Asignaciones.Select(a => new ReporteCursoDto(
                        a.Curso!.Nomb_cur,
                        a.Curso.Matriculas
                            // Agrupamos las matrículas del curso por provincia directamente
                            .GroupBy(m => m.Estudiante!.Distrito!.Provincia!)
                            .Select(g => new ReporteProvinciaDto(
                                g.Key.Nomb_pro,
                                g.Select(m => m.Estudiante!.Nomb_est + " " + m.Estudiante.Apel_est).ToList()
                            )).ToList()
                    )).ToList()
                )).ToListAsync();
        }
    }
}
