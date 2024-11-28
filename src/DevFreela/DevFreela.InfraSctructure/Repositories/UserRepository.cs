using DevFreela.Core.Entitiees;
using DevFreela.Core.Repositories;
using DevFreela.InfraSctructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.InfraSctructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDbContext _context;
        public UserRepository(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(User user)
        {
            var teste = await _context.Users.AddAsync(user);
            _context.SaveChanges();

            return user.Id;            
        }

        public Task<bool> Exists(int id)
        {
            return _context.Users.AnyAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        public async Task Update(User user)
        {
            _context. Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
