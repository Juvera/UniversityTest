using System;
using System.Collections.Generic;
using System.Text;

namespace AchillesTest.Application.DTOs
{
    public class ProvinciaDto
    {
        public int IdProvincia { get; set; }
        public string? Nomb_pro { get; set; }

        public ProvinciaDto(int idProvincia, string? nomb_pro)
        {
            IdProvincia = idProvincia;
            Nomb_pro = nomb_pro;
        }
    }
}
