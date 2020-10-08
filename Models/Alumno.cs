using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPNetCore.Models
{
    public class Alumno : ObjetoBase
    {
        [Required(ErrorMessage = "El nombre del alumno es requerido.")]
        [Display(Prompt = "Escriba nombre del alumno")]
        public override string Nombre { get; set; }

        [Required(ErrorMessage = "La asignatura requiere estar ligado a un curso.")]
        public Guid CursoId { get; set; }
        public Curso Curso { get; set; }
        public List<Evaluacion> Evaluaciones { get; set; }
    }
}