using AchillesTest.Application.DTOs;
using AchillesTest.Application.Interfaces;
using AchillesTest.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AchillesTest.Application.Service
{
    public class DistritoService : IDistritoService
    {
        private readonly UniversidadDbContext _context;

        public DistritoService(UniversidadDbContext context)
        {
            _context = context;
        }

        public async Task<List<DistritoDto>> GetDistritos()
        {
            return await _context.TB_DISTRITO
                .AsNoTracking()
                .Select(d => new DistritoDto
                    (
                        d.IdDistrito,
                        d.Nomb_dis,
                        d.Provincia!.Nomb_pro
                    ))
                .ToListAsync();
        }
    }
}
