using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdeem.Core.Entities
{
    public class EntityBase
    {
        public EntityBase()
        {
             Id = Guid.NewGuid();
        }
        public Guid Id { get; private set; }
    }
}
