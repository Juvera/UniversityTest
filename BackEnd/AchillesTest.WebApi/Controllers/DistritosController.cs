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
    public class DistritosController : ControllerBase
    {
        private readonly IDistritoService _distritoService;

        public DistritosController(IDistritoService distritoService)
        {
            _distritoService = distritoService;
        }

        /// <summary>
        /// Obtiene un listado de todos los distritos
        /// </summary>
        [HttpGet("")]
        public async Task<ActionResult<List<DistritoDto>>> GetDistritos()
        {
            var result = await _distritoService.GetDistritos();
            return Ok(result);
        }
    }
}
