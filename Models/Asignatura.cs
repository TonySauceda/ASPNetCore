using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASPNetCore.Models
{
    public class Asignatura : ObjetoBase
    {
        [Required(ErrorMessage = "El nombre de la asignatura es requerido.")]
        [Display(Prompt = "Escriba nombre de la asignatura")]
        [StringLength(250, ErrorMessage = "El nombre de la asignatura no puede ser mayor a 250 caracteres.")]
        public override string Nombre { get; set; }

        [Required(ErrorMessage = "La asignatura requiere estar ligado a un curso.")]
        public Guid CursoId { get; set; }
        public Curso Curso { get; set; }
        public List<Evaluacion> Evaluaciones { get; set; }
    }
}