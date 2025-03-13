using DevFreela.Core.Entitiees;
using DevFreela.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.UnitTests.Core
{
    public class ProjectTests
    {
        [Fact]
        public void ProjectIsCreated_Start_Success()
        {
            //Arrange
            var project = new Project("Projeto A", "Descrição do projeto", 1, 2, 1000);

            //Act
            project.Start();

            //Assert
            Assert.Equal(ProjectsStatusEnum.InProgress, project.Status);
            Assert.NotNull(project.StartedAt);
            Assert.True(project.Status == ProjectsStatusEnum.InProgress);
            Assert.False(project.StartedAt is null);

        }

        [Fact]
        public void ProjectIsInvalidState_Start_ThrowsException()
        {
            //Arrange
            var project = new Project("Projeto A", "Descrição do projeto", 1, 2, 1000);
            project.Start();

            // Act
            Action? start = project.Start;

            //Assert
            var exception = Assert.Throws<InvalidOperationException>(start);
            Assert.Equal("Erro", exception.Message);

        }
    }
}
