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
            CreatedAt = DateTime.Now;
            IsDeleted = false;
        }

        protected BaseEntity() { }
        public int Id { get; set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsDeleted { get; private set; }

        public void SetAsDeleted()
        {
            IsDeleted = true;
        }
    }
}
