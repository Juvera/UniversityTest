using AchillesTest.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AchillesTest.Application.Interfaces
{
    public interface ICursoService
    {
        Task<List<CursoDto>> GetCursos();
    }
}
