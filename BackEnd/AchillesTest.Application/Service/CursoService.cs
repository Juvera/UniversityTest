using AchillesTest.Application.DTOs;
using AchillesTest.Application.Interfaces;
using AchillesTest.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AchillesTest.Application.Service
{
    public class CursoService : ICursoService
    {
        private readonly UniversidadDbContext _context;

        public CursoService(UniversidadDbContext context)
        {
            _context = context;
        }

        public async Task<List<CursoDto>> GetCursos()
        {
            return await _context.TB_CURSO
                .AsNoTracking()
                .Select(d => new CursoDto
                    (
                        d.IdCurso,
                        d.Nomb_cur,
                        d.Dura_cur
                    ))
                .ToListAsync();
        }
    }
}
