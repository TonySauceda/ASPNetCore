using System;

namespace ASPNetCore.Models
{
    public class AlumnoPromedioModel
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public float Promedio { get; set; }
    }
}