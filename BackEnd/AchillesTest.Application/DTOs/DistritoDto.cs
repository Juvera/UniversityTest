using AchillesTest.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AchillesTest.Application.DTOs
{
    public class DistritoDto
    {
        public int IdDistrito { get; set; }
        public string? Nomb_dis { get; set; }
        public string? Provincia { get; set; }

        public DistritoDto(int idDistrito, string? nomb_dis, string? provincia)
        {
            IdDistrito = idDistrito;
            Nomb_dis = nomb_dis;
            Provincia = provincia;
        }
    }
}
