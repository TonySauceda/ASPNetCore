using System;

namespace ASPNetCore.Models
{
    public abstract class ObjetoBase
    {
        public Guid Id { get; private set; }
        public string Nombre { get; set; }

        public ObjetoBase() => Id = Guid.NewGuid();
    }
}