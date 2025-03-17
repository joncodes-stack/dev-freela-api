using DevFreela.Aplication.Commands.Projects.InsertComment;
using DevFreela.Aplication.Commands.Projects.InsertProject;
using DevFreela.Core.Entitiees;
using DevFreela.Core.Repositories;
using Moq;
using NSubstitute;

namespace DevFreela.Tests.Application
{
    public class InsertProjectHandlerTests
    {
        [Fact]
        public async Task InputDataAreOk_Insert_Sucess_NSubstitute()
        {
            //Arrange
            var repository = Substitute.For<IProjectRepository>();
            repository.Add(Arg.Any<Project>()).Returns(Task.FromResult(1));

            var command = new InsertProjectCommand
            {
                Title = "Project A",
                Description = "Descrição do Projeto",
                TotalCost = 2000,
                IdClient = 1,
                IdFreelancer = 2
            };

            var handler = new InsertProjectHandler(repository);

            //Act
            var result = await handler.Handle(command, new CancellationToken());

            //Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(1, result.Data);
            await repository.Received(1).Add(Arg.Any<Project>());
        }

        [Fact]
        public async Task InputDataAreOk_Insert_Sucess_Moq()
        {
            //Arrange
            const int ID = 1;

            var mock = new Mock<IProjectRepository>();
            mock.Setup(r => r.Add(It.IsAny<Project>())).ReturnsAsync(ID);

            var command = new InsertProjectCommand
            {
                Title = "Project A",
                Description = "Descrição do Projeto",
                TotalCost = 2000,
                IdClient = 1,
                IdFreelancer = 2
            };

            var handler = new InsertProjectHandler(mock.Object);

            //Act
            var result = await handler.Handle(command, new CancellationToken());

            //Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(1, result.Data);

            mock.Verify(m => m.Add(It.IsAny<Project>()), Times.Once);
        }
    }
}
