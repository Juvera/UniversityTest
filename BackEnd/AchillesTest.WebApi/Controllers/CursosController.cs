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
    public class CursosController : ControllerBase
    {
        private readonly ICursoService _cursoService;

        public CursosController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        /// <summary>
        /// Obtiene un listado de todos los cursos
        /// </summary>
        [HttpGet("")]
        public async Task<ActionResult<List<CursoDto>>> GetCursos()
        {
            var result = await _cursoService.GetCursos();
            return Ok(result);
        }
    }
}
