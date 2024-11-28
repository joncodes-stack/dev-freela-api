using DevFreela.Core.Entitiees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task<int> Add(User user);
        Task Update(User user);
        Task<bool> Exists(int id);
    }
}
