using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ASPNetCore.Enums;

namespace ASPNetCore.Models
{
    public class Curso : ObjetoBase
    {
        [Required(ErrorMessage = "El nombre del curso es requerido.")]
        [Display(Prompt = "Escriba nombre del curso")]
        [StringLength(5)]
        public override string Nombre { get; set; }
        public Guid EscuelaId { get; set; }
        public Escuela Escuela { get; set; }

        [Required(ErrorMessage = "El tipo de curso es requerido.")]
        public TipoCursoEnum TipoCurso { get; set; }

        [Required(ErrorMessage = "Se requiere incluir una dirección.")]
        [MinLength(10, ErrorMessage = "La longitud mínima de la dirección es 10")]
        [Display(Prompt = "Escriba la dirección", Name = "Dirección")]
        public string Direccion { get; set; }
        public List<Asignatura> Asignaturas { get; set; }
        public List<Alumno> Alumnos { get; set; }
    }
}