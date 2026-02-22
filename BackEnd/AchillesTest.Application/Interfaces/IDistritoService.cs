using AchillesTest.Application.DTOs;
using AchillesTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AchillesTest.Application.Interfaces
{
    public interface IDistritoService
    {
        Task<List<DistritoDto>> GetDistritos();
    }
}
