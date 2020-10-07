using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ASPNetCore.Enums;

namespace ASPNetCore.Models
{
    public class Curso : ObjetoBase
    {
        [Required]
        public override string Nombre { get; set; }
        public Guid EscuelaId { get; set; }
        public Escuela Escuela { get; set; }
        public TipoCursoEnum TipoCurso { get; set; }
        public string Dirección { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }
    }
}