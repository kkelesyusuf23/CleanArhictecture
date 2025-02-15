using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArhictecture.Domain.Abstractions
{
    public abstract class EntityDto
    {
        public Guid Id { get; set; }

        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeleteAt { get; set; }
    }
}
