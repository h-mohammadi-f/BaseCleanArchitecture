using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public abstract class EntitytBase
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
    }
}