using System;
using System.Collections.Generic;
using ASPNetCore.Enums;

namespace ASPNetCore.Models
{
    public class Curso : ObjetoBase
    {
        public Guid EscuelaId { get; set; }
        public Escuela Escuela { get; set; }
        public TipoCursoEnum TipoCurso { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }
        public string Direccion { get; set; }
    }
}