using DevFreela.Core.Entitiees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAll();
        Task<Project> GetDetailsById(int id);
        Task<Project> GetById(int id);
        Task<int> Add(Project project);
        Task AddComment(ProjectComment comment);
        Task Update(Project project);
        Task<bool> Exists(int id);
    }
}
