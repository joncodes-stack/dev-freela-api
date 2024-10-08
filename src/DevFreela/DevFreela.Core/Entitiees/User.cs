﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Entitiees
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, DateTime birthDate)
            : base()
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Active = true;

            Skills = [];
            OwenedProjects = [];
            FreelancerProjects = [];
            Comments = [];
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool Active { get; private set; }
        public List<UserSkill> Skills { get; private set; }
        public List<Project> OwenedProjects { get; private set; }
        public List<Project> FreelancerProjects { get; private set; }
        public List<ProjectComment> Comments { get; set; }
    }
}
