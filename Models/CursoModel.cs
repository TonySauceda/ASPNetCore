using System.Collections.Generic;
using ASPNetCore.Enums;

namespace ASPNetCore.Models
{
    public class CursoModel : ObjetoBase
    {
        public TipoCursoEnum TipoCurso { get; set; }
        public List<AsignaturaModel> Asignaturas { get; set; }
        public List<AlumnoModel> Alumnos { get; set; }
        public string Direccion { get; set; }
    }
}