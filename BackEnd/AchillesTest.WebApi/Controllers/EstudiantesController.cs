using AchillesTest.Application.DTOs;
using AchillesTest.Application.Interfaces;
using AchillesTest.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AchillesTest.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudiantesController : ControllerBase
    {
        private readonly IEstudianteService _estudianteService;

        public EstudiantesController(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }

        /// <summary>
        /// Inserta un nuevo estudiante.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Estudiante estudiante)
        {
            var id = await _estudianteService.InsertarEstudiante(estudiante);
            return CreatedAtAction(nameof(Post), new { id = id }, estudiante);
        }

        /// <summary>
        /// Obtiene los estudiantes de una provincia.
        /// </summary>
        [HttpGet("provincia/{idProvincia}")]
        public async Task<ActionResult<PagedResult<EstudianteDto>>> GetPorProvincia(
            int idProvincia,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var result = await _estudianteService.ObtenerPorProvincia(idProvincia, pageNumber, pageSize);
            return Ok(result);
        }

        /// <summary>
        /// Obtiene las estadísticas de estudiantes por provincia.
        /// </summary>
        [HttpGet("estadisticas")]
        public async Task<ActionResult<PagedResult<EstadisticasProvinciasDto>>> GetEstadisticas(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var result = await _estudianteService.GetEstadisticasProvincias(pageNumber, pageSize);
            return Ok(result);
        }

        /// <summary>
        /// Obtiene el reporte jerárquico de Docentes -> Cursos -> Provincias -> Alumnos.
        /// </summary>
        [HttpGet("reporte-jerarquico")]
        public async Task<ActionResult<List<ReporteDocenteDto>>> GetReporte()
        {
            var result = await _estudianteService.GetReporteJerarquico();
            return Ok(result);
        }

        /// <summary>
        /// Obtiene la provincia más popular para un curso.
        /// </summary>
        [HttpGet("curso/{idCurso}/provincia-popular")]
        public async Task<IActionResult> GetProvinciaPopular(int idCurso)
        {
            var result = await _estudianteService.ObtenerProvinciaPopularPorCurso(idCurso);
            if (result == null) 
                return NotFound("No se encontraron datos para este curso.");
            return Ok(result);
        }
    }
}
