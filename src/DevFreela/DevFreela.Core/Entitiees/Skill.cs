using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Entitiees
{
    public class Skill : BaseEntity
    {
        public Skill(string description, DateTime createdAt) : base()
        {
            Description = description;
        }

        public string Description { get; private set; }
        public List<UserSkill> UserSkills { get; set; }
    }
}
