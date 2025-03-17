using DevFreela.Aplication.Commands.Projects.DeleteProject;
using DevFreela.Core.Entitiees;
using DevFreela.Core.Repositories;
using Moq;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Tests.Application
{
    public class DeleteProjectHandlerTests
    {
        [Fact]
        public async Task ProjectExists_Delete_Sucess_NSubstitute()
        {
            //Arrangee
            var project = new Project("Projeto A", "Descricao do projeto", 1, 2, 10000);

            var repository = Substitute.For<IProjectRepository>();
            repository.GetById(Arg.Any<int>()).Returns(Task.FromResult((Project?)project));
            repository.Update(Arg.Any<Project>()).Returns(Task.CompletedTask);

            var handler = new DeleteProjectHandler(repository);

            var command = new DeleteProjectCommand(1);

            //Act
            var result = await handler.Handle(command, new CancellationToken());

            //Assert
            Assert.True(result.IsSuccess);
            await repository.Received(1).GetById(1);
            await repository.Received(1).Update(Arg.Any<Project>());

        }

        [Fact]
        public async Task ProjectDoesNotExists_Delete_Error_NSubstitute()
        {
            //Arrange
            var repository = Substitute.For<IProjectRepository>();
            repository.GetById(Arg.Any<int>()).Returns(Task.FromResult((Project?)null));

            var handler = new DeleteProjectHandler(repository);

            var command = new DeleteProjectCommand(1);

            // Act
            var result = await handler.Handle(command, new CancellationToken());

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Projeto não Existe", result.Message); 

            await repository.Received(1).GetById(Arg.Any<int>());
            await repository.DidNotReceive().Update(Arg.Any<Project>());
        }

        [Fact]
        public async Task ProjectExists_Delete_Sucess_Moq()
        {
            //Arrangee
            var project = new Project("Projeto A", "Descricao do projeto", 1, 2, 10000);

            var repository = Mock.Of<IProjectRepository>(p => p.GetById(It.IsAny<int>()) == Task.FromResult(project) && p.Update(It.IsAny<Project>()) == Task.CompletedTask);

            var handler = new DeleteProjectHandler(repository);

            var command = new DeleteProjectCommand(1);

            //Act
            var result = await handler.Handle(command, new CancellationToken());

            //Assert
            Assert.True(result.IsSuccess);
            Mock.Get(repository).Verify(r => r.GetById(1), Times.Once);
            Mock.Get(repository).Verify(r => r.Update(It.IsAny<Project>()), Times.Once);
        }

        [Fact]
        public async Task ProjectDoesNotExists_Delete_Error_Moq()
        {
            //Arrange
            var repository = Mock.Of<IProjectRepository>(p => p.GetById(It.IsAny<int>()) == Task.FromResult((Project?) null));

            var handler = new DeleteProjectHandler(repository);

            var command = new DeleteProjectCommand(1);

            // Act
            var result = await handler.Handle(command, new CancellationToken());

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Projeto não Existe", result.Message);

            Mock.Get(repository).Verify(r => r.GetById(1), Times.Once);
            Mock.Get(repository).Verify(r => r.Update(It.IsAny<Project>()), Times.Never);
        }
    }
}
