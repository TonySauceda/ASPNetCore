using System;

namespace ASPNetCore.Models
{
    public class Evaluacion : ObjetoBase
    {
        public Guid AlumnoId { get; set; }
        public Alumno Alumno { get; set; }
        public Guid AsignaturaId { get; set; }
        public Asignatura Asignatura { get; set; }
        public float Calificacion { get; set; }
    }
}