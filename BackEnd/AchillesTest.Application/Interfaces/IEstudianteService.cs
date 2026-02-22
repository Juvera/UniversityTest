using AchillesTest.Application.DTOs;
using AchillesTest.Domain.Entities;
using AchillesTest.Domain.StoreProcedure;

namespace AchillesTest.Application.Interfaces
{
    public interface IEstudianteService
    {

        /// <summary>
        /// Obtiene estadísticas de estudiantes por provincia de forma paginada.
        /// </summary>
        Task<PagedResult<EstadisticasProvinciasDto>> GetEstadisticasProvincias(int pageNumber, int pageSize);


        /// <summary>
        /// Ejecuta el procedimiento almacenado para encontrar la provincia con más alumnos en un curso.
        /// </summary>
        Task<ProvinciaPopularResult?> ObtenerProvinciaPopularPorCurso(int idCurso);

        /// <summary>
        /// Inserta un estudiante y retorna su ID.
        /// </summary>
        Task<int> InsertarEstudiante(Estudiante estudiante);

        /// <summary>
        /// Obtiene estudiantes por provincia con soporte de paginación.
        /// </summary>
        Task<PagedResult<EstudianteDto>> ObtenerPorProvincia(int idProvincia, int pageNumber, int pageSize);

        /// <summary>
        /// Obtiene el reporte jerárquico paginando la entidad raíz (Docentes).
        /// </summary>
        Task<List<ReporteDocenteDto>> GetReporteJerarquico();

    }
}
