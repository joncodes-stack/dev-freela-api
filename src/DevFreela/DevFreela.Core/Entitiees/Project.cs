using DevFreela.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Entitiees
{
    public class Project : BaseEntity
    {
        protected Project() { }

        public Project(string title, string description, int idClient, int idFreelancer, decimal totalCost)
           : base()
        {
            Title = title;
            Description = description;
            IdClient = idClient;
            IdFreelancer = idFreelancer;
            TotalCost = totalCost;

            Status = ProjectsStatusEnum.Created;
            Comments = [];
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public int IdClient { get; private set; }
        public User Client { get; set; }
        public int IdFreelancer { get; private set; }
        public User Freelancer { get; set; }
        public decimal TotalCost { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? CompletedAt { get; private set; }
        public ProjectsStatusEnum Status { get;  private set; }
        public List<ProjectComment> Comments { get; private set; }

        public void Cancel()
        {
            if (Status == ProjectsStatusEnum.InProgress || Status == ProjectsStatusEnum.Suspended)
            {
                Status = ProjectsStatusEnum.Cancelled;
            }
        }

        public void Start()
        {
            if (Status == ProjectsStatusEnum.Created)
            {
                Status = ProjectsStatusEnum.InProgress;
                StartedAt = DateTime.Now;
            }
        }

        public void Complete()
        {
            if (Status == ProjectsStatusEnum.PaymentPending || Status == ProjectsStatusEnum.InProgress)
            {
                Status = ProjectsStatusEnum.Completed;
                CompletedAt = DateTime.Now;
            }
        }

        public void SetPaimentPending()
        {
            if (Status == ProjectsStatusEnum.InProgress)
            {
                Status = ProjectsStatusEnum.PaymentPending;
            }
        }

        public void Update(string title, string description, decimal totalCost)
        {
            Title = title;
            Description = description;
            TotalCost = totalCost;
        }
    }
}
