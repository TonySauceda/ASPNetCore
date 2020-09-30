using System.Collections.Generic;

namespace ASPNetCore.Models
{
    public class AlumnoModel : ObjetoBase
    {
        public List<EvaluacionModel> Evaluaciones { get; set; } = new List<EvaluacionModel>();
    }
}