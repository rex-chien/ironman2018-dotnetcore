using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ironman2018.Models.DependecyInjection
{
    public class Operation :
        IOperationTransient,
        IOperationScoped,
        IOperationSingleton,
        IOperationSingletonInstance
    {
        public Operation() : this(Guid.NewGuid())
        {
        }

        public Operation(Guid id)
        {
            OperationId = id;
        }

        public Guid OperationId { get; }
    }
}
