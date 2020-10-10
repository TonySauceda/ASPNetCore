using System;
using System.Collections.Generic;
using System.Linq;
using ASPNetCore.Enums;
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

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            var escuela = new Escuela("Platzi Academy", 2014);
            escuela.TipoEscuela = Enums.TipoEscuelaEnum.Secundaria;
            escuela.Ciudad = "Mazatlán";
            escuela.Direccion = "Calle siempre viva";
            escuela.Pais = "México";

            //Generar Cursos
            var cursos = CargarCursos(escuela);
            //Generar Asignatuas
            var asignaturas = CargarAsignaturas(cursos);
            //Generar Alumnos
            var alumnos = CargarAlumnos(cursos);
            //Generar Evaluaciones
            var evaluaciones = CargarEvaluaciones(cursos, alumnos, asignaturas);

            modelBuilder.Entity<Escuela>().HasData(escuela);
            modelBuilder.Entity<Curso>().HasData(cursos);
            modelBuilder.Entity<Asignatura>().HasData(asignaturas);
            modelBuilder.Entity<Alumno>().HasData(alumnos);
            modelBuilder.Entity<Evaluacion>().HasData(evaluaciones);
        }

        private IEnumerable<Evaluacion> CargarEvaluaciones(IEnumerable<Curso> cursos, IEnumerable<Alumno> alumnos, IEnumerable<Asignatura> asignaturas)
        {
            List<Evaluacion> resultado = new List<Evaluacion>();
            var rand = new Random();
            foreach (var curso in cursos)
            {
                foreach (var alumno in alumnos)
                {
                    foreach (var asignatura in asignaturas)
                    {
                        resultado.Add(new Evaluacion
                        {
                            AlumnoId = alumno.Id,
                            AsignaturaId = asignatura.Id,
                            Nombre = asignatura.Nombre,
                            Calificacion = MathF.Round((float)(rand.NextDouble() * 5), 2)
                        });
                    }
                }
            }

            return resultado;
        }

        private IEnumerable<Asignatura> CargarAsignaturas(IEnumerable<Curso> cursos)
        {
            List<Asignatura> resultado = new List<Asignatura>();
            foreach (var curso in cursos)
            {
                var temp = new List<Asignatura>()
                {
                    new Asignatura(){ CursoId = curso.Id, Nombre = "Matemáticas" },
                    new Asignatura(){ CursoId = curso.Id, Nombre = "Educación Física" },
                    new Asignatura(){ CursoId = curso.Id, Nombre = "Español" },
                    new Asignatura(){ CursoId = curso.Id, Nombre = "Ciencias Naturales" },
                    new Asignatura(){ CursoId = curso.Id, Nombre = "Programación Básica" },
                };

                resultado.AddRange(temp);
            }

            return resultado;
        }

        private IEnumerable<Curso> CargarCursos(Escuela escuela)
        {
            return new List<Curso>
            {
                new Curso() { Nombre = "101", Direccion = "Dirección 101", EscuelaId = escuela.Id, TipoCurso = TipoCursoEnum.Mañana },
                new Curso() { Nombre = "201", Direccion = "Dirección 201", EscuelaId = escuela.Id, TipoCurso = TipoCursoEnum.Mañana },
                new Curso() { Nombre = "301", Direccion = "Dirección 301", EscuelaId = escuela.Id, TipoCurso = TipoCursoEnum.Mañana },
                new Curso() { Nombre = "102", Direccion = "Dirección 102", EscuelaId = escuela.Id, TipoCurso = TipoCursoEnum.Tarde },
                new Curso() { Nombre = "202", Direccion = "Dirección 202", EscuelaId = escuela.Id, TipoCurso = TipoCursoEnum.Tarde },
                new Curso() { Nombre = "302", Direccion = "Dirección 302", EscuelaId = escuela.Id, TipoCurso = TipoCursoEnum.Tarde },
                new Curso() { Nombre = "103", Direccion = "Dirección 103", EscuelaId = escuela.Id, TipoCurso = TipoCursoEnum.Noche },
                new Curso() { Nombre = "203", Direccion = "Dirección 203", EscuelaId = escuela.Id, TipoCurso = TipoCursoEnum.Noche },
                new Curso() { Nombre = "303", Direccion = "Dirección 303", EscuelaId = escuela.Id, TipoCurso = TipoCursoEnum.Noche },
            };
        }

        private IEnumerable<Alumno> GenerarAlumnosRandom(Curso curso, int cantidad)
        {
            List<Alumno> resultado = new List<Alumno>();
            string[] nombre1 = { "Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás" };
            string[] apellido1 = { "Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera" };
            string[] nombre2 = { "Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro" };

            var listaAlumnos = (from n1 in nombre1
                                from n2 in nombre2
                                from a1 in apellido1
                                select new Alumno() { Nombre = $"{n1} {n2} {a1}", CursoId = curso.Id });

            return listaAlumnos.OrderBy(x => x.Id).Take(cantidad).ToList();
        }

        private IEnumerable<Alumno> CargarAlumnos(IEnumerable<Curso> cursos)
        {
            List<Alumno> resultado = new List<Alumno>();
            var rand = new Random();
            foreach (var curso in cursos)
            {
                var temp = GenerarAlumnosRandom(curso, rand.Next(3, 5));
                resultado.AddRange(temp);
            }

            return resultado;
        }
    }
}