using System.Collections.Generic;
using ASPNetCore.Enums;

namespace ASPNetCore.Models
{
    public class EscuelaModel : ObjetoBase
    {
        public int AñoDeCreación { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public TipoEscuelaEnum TipoEscuela { get; set; }
        public List<CursoModel> Cursos { get; set; }
        public string Direccion { get; set; }

        public EscuelaModel(string nombre, int año) => (Nombre, AñoDeCreación) = (nombre, año);
        public EscuelaModel(string nombre, int año, TipoEscuelaEnum tipo, string pais = "", string ciudad = "")
        {
            Nombre = nombre;
            AñoDeCreación = año;
            TipoEscuela = tipo;
            Pais = pais;
            Ciudad = ciudad;
        }
    }
}