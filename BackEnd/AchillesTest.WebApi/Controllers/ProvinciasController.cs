using AchillesTest.Application.DTOs;
using AchillesTest.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AchillesTest.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProvinciasController : ControllerBase
    {
        private readonly IProvinciaService _provinciaService;

        public ProvinciasController(IProvinciaService provinciaService)
        {
            _provinciaService = provinciaService;
        }

        /// <summary>
        /// Obtiene un listado de todas las provincias
        /// </summary>
        [HttpGet("")]
        public async Task<ActionResult<List<ProvinciaDto>>> GetProvincias()
        {
            var result = await _provinciaService.GetProvincias();
            return Ok(result);
        }
    }
}
