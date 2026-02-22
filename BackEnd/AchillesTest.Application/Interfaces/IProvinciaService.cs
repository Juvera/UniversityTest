using AchillesTest.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace AchillesTest.Application.Interfaces
{
    public interface IProvinciaService
    {
        Task<List<ProvinciaDto>> GetProvincias();
    }
}
