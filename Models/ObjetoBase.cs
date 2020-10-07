using System;

namespace ASPNetCore.Models
{
    public abstract class ObjetoBase
    {
        public Guid Id { get; private set; }
        public virtual string Nombre { get; set; }

        public ObjetoBase() => Id = Guid.NewGuid();
    }
}