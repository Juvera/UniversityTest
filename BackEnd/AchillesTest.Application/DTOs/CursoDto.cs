using System;
using System.Collections.Generic;
using System.Text;

namespace AchillesTest.Application.DTOs
{
    public class CursoDto
    {
        public int IdCurso { get; set; }
        public string? Nomb_cur { get; set; }
        public string? Dura_cur { get; set; }

        public CursoDto(int idDistrito, string? nomb_cur, string? dura_cur)
        {
            IdCurso = idDistrito;
            Nomb_cur = nomb_cur;
            Dura_cur = dura_cur;
        }
    }
}
