using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntVisionLibraries.Common.Domain
{
    public class EntityValidationResult<TEntity> 
        where TEntity : class
    {
        public virtual bool IsValid { get; set; }
        public IList<EntityValidationFailure> Errors { get; set; }
        public TEntity Object { get; set; }
    }
}
