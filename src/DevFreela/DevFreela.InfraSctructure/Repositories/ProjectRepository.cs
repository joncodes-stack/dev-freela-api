﻿using Azure.Core;
using DevFreela.Core.Entitiees;
using DevFreela.Core.Repositories;
using DevFreela.InfraSctructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.InfraSctructure.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelaDbContext _context;
        public ProjectRepository(DevFreelaDbContext context)
        {
            _context = context;
        }

        public async Task<int> Add(Project project)
        {
            await _context.Projects.AddAsync(project);
            _context.SaveChanges();

            return project.Id;
        }

        public async Task AddComment(ProjectComment comment)
        {
            await _context.ProjectComments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Projects.AnyAsync(p => p.Id == id);
        }

        public async Task<List<Project>> GetAll()
        {
            var projects = await _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .Where(p => !p.IsDeleted).ToListAsync();

            return projects;
        }

        public async Task<Project> GetById(int id)
        {
            return _context.Projects.SingleOrDefault(p => p.Id == id);
        }

        public async Task<Project> GetDetailsById(int id)
        {
            var projects = await _context.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .Include(p => p.Comments)
                .SingleOrDefaultAsync(p => p.Id == id);

            return projects;
        }

        public async Task Update(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }
    }
}