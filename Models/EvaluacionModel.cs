namespace ASPNetCore.Models
{
    public class EvaluacionModel : ObjetoBase
    {
        public AlumnoModel Alumno { get; set; }
        public AsignaturaModel Asignatura { get; set; }
        public float Calificacion { get; set; }
    }
}