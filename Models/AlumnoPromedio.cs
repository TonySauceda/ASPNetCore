using System;

namespace ASPNetCore.Models
{
    public class AlumnoPromedio
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public float Promedio { get; set; }
    }
}