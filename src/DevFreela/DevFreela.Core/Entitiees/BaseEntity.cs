using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Entitiees
{
    public abstract class BaseEntity
    {
        public BaseEntity(int id, DateTime createdAt)
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }

        protected BaseEntity() { }
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsDeleted { get; private set; }

        public void SetAsDeleted()
        {
            IsDeleted = true;
        }
    }
}
