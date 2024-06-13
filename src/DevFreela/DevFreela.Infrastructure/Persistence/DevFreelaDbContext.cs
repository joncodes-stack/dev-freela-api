using DevFreela.Core.Entitiees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                    new Project("teste", "descrição", 1, 2, 1000),
                    new Project("teste", "descrição", 1, 2, 1000),
                    new Project("teste", "descrição", 1, 2, 1000)
            };

            Users = new List<User>
            {
                    new User("jonatas", "martinsreanta@gmail.com", DateTime.Now),
                    new User("jonatas", "martinsreanta@gmail.com", DateTime.Now),
                    new User("jonatas", "martinsreanta@gmail.com", DateTime.Now),
            };

            Skills = new List<Skill>
            {
                    new Skill("teste", DateTime.Now),
                    new Skill("teste", DateTime.Now),
                    new Skill("teste", DateTime.Now)
            };
        }

        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
