using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Entitiees
{
    public class BaseEntity
    {
        public BaseEntity(int id, DateTime createdAt)
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }

        protected BaseEntity() { }
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
