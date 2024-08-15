using DevFreela.Core.Entitiees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.InfraSctructure.Context
{
    public class DevFreelaDbContext : DbContext
    {
        public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> options)
            : base(options)
        {

        }

        public DbSet<Project> Projects {  get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<ProjectComment> ProjectComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Project>(e =>
                {
                    e.HasKey(e => e.Id);
                });

            modelBuilder
                .Entity<UserSkill>(e =>
                {
                    e.HasKey(e => e.Id);

                    e.HasOne(e => e.Skill)
                    .WithMany(u => u.UserSkills)
                    .HasForeignKey(s => s.IdSkill)
                    .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder
                .Entity<ProjectComment>(e =>
                {
                    e.HasKey(p => p.Id);

                    e.HasOne(p => p.Project)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(p => p.IdProject)
                    .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder
                .Entity<User>(e =>
                {
                    e.HasKey(p => p.Id);

                    e.HasMany(u => u.Skills)
                    .WithOne(us => us.User)
                    .HasForeignKey(us => us.IdUser)
                    .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder
                .Entity<Project>(e =>
                {
                    e.HasKey(p => p.Id);

                    e.HasOne(p => p.Freelancer)
                    .WithMany(f => f.FreelancerProjects)
                    .HasForeignKey(p => p.IdFreelancer)
                    .OnDelete(DeleteBehavior.Restrict);

                    e.HasOne(p => p.Client)
                    .WithMany(c => c.OwenedProjects)
                    .HasForeignKey(p => p.IdClient)
                    .OnDelete(DeleteBehavior.Restrict);
                });

            base.OnModelCreating(modelBuilder);
        }

    }
}
