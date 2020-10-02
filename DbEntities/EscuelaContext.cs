using System.Collections.Generic;
using System.Linq;
using ASPNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCore.DbEntities
{
    public class EscuelaContext : DbContext
    {
        public DbSet<Escuela> Escuelas { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Evaluacion> Evaluaciones { get; set; }

        public EscuelaContext(DbContextOptions<EscuelaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var escuela = new Escuela("Platzi Academy", 2014);
            escuela.TipoEscuela = Enums.TipoEscuelaEnum.Secundaria;
            escuela.Ciudad = "Mazatlán";
            escuela.Direccion = "Calle siempre viva";
            escuela.Pais = "México";

            modelBuilder.Entity<Escuela>().HasData(escuela);

            var lsAsignaturas = new List<Asignatura>()
                {
                    new Asignatura(){ Nombre = "Matemáticas" },
                    new Asignatura(){ Nombre = "Educación Física" },
                    new Asignatura(){ Nombre = "Español" },
                    new Asignatura(){ Nombre = "Ciencias Naturales" },
                    new Asignatura(){ Nombre = "Programación Básica" },
                };

            modelBuilder.Entity<Asignatura>().HasData(lsAsignaturas);

            var lsAlumnos = CargarAlumnos();

            modelBuilder.Entity<Alumno>().HasData(lsAlumnos);
        }

        private IEnumerable<Alumno> CargarAlumnos()
        {
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = (from n1 in nombre1
                                from n2 in nombre2
                                from a1 in apellido1
                                select new Alumno() { Nombre = $"{n1} {n2} {a1}" });

            return listaAlumnos.OrderBy(x => x.Id).ToList();
        }
    }
}