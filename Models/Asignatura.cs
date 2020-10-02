using System;
using System.Collections.Generic;

namespace ASPNetCore.Models
{
    public class Asignatura : ObjetoBase
    {
        public Guid CursoId { get; set; }
        public Curso Curso { get; set; }
        public List<Evaluacion> Evaluaciones { get; set; }
    }
}