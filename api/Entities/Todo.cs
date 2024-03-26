using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Entities
{
    public class Todo
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Description { get; set; } = null!;
    }
}