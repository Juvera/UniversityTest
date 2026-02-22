using AchillesTest.Application.DTOs;
using AchillesTest.Application.Interfaces;
using AchillesTest.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AchillesTest.Application.Service
{
    public class ProvinciaService : IProvinciaService
    {
        private readonly UniversidadDbContext _context;

        public ProvinciaService(UniversidadDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProvinciaDto>> GetProvincias()
        {
            return await _context.TB_PROVINCIA
                .AsNoTracking()
                .Select(d => new ProvinciaDto
                    (
                        d.IdProvincia,
                        d.Nomb_pro
                    ))
                .ToListAsync();
        }
    }
}
