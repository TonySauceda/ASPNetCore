using System;

namespace ASPNetCore.Models
{
    public class Asignatura : ObjetoBase
    {
        public Guid CursoId { get; set; }
        public Curso Curso { get; set; }
    }
}