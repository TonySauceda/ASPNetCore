using System.Collections.Generic;
using ASPNetCore.Enums;

namespace ASPNetCore.Models
{
    public class Escuela : ObjetoBase
    {
        public int AñoDeCreación { get; set; }
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public TipoEscuelaEnum TipoEscuela { get; set; }
        public List<Curso> Cursos { get; set; }
        public string Direccion { get; set; }

        public Escuela(string nombre, int añoDeCreación) => (Nombre, AñoDeCreación) = (nombre, añoDeCreación);
        public Escuela(string nombre, int añoDeCreación, TipoEscuelaEnum tipoEscuela, string pais = "", string ciudad = "")
        {
            Nombre = nombre;
            AñoDeCreación = añoDeCreación;
            TipoEscuela = tipoEscuela;
            Pais = pais;
            Ciudad = ciudad;
        }
    }
}