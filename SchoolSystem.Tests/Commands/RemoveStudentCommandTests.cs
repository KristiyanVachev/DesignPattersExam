using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SchoolSystem.Framework.Core;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Tests.Commands
{
    [TestFixture]
    public class RemoveStudentCommandTests
    {
        [Test]
        public void Execute_ShouldCallStudentsFromDatabase()
        {
            //Arrange
            var mockDatabase = new Mock<IDatabase>();

            var command = new RemoveStudentCommand(mockDatabase.Object);

            var fakeCommand = new List<string> { "0" };

            mockDatabase.Setup(x => x.Students.Remove(It.IsAny<int>()));

            //Act
            command.Execute(fakeCommand);

            //Assert
            mockDatabase.Verify(x => x.Students.Remove(0));
        }

        [Test]
        public void Execute_RemoveUserWithProvidedId()
        {
            //Arrange
            var database = new Database();
            database.Students.Add(0, new Student("Dracula", "lalala", Grade.Eleventh));

            var command = new RemoveStudentCommand(database);

            var fakeCommand = new List<string> { "0" };

            var countBeforeRemoval = database.Students.Count;
            //Act
            command.Execute(fakeCommand);

            //Assert
            Assert.IsTrue(database.Students.Count == countBeforeRemoval - 1);
        }

        [Test]
        public void Execute_ReturnProperMessageWhenRemovedCorrectly()
        {
            //Arrange
            var mockDatabase = new Mock<IDatabase>();

            var command = new RemoveStudentCommand(mockDatabase.Object);

            var fakeCommand = new List<string> { "0" };

            mockDatabase.Setup(x => x.Students.Remove(It.IsAny<int>()));
            var expectedOutput = "was sucessfully removed.";

            //Act
            var output = command.Execute(fakeCommand);

            //Assert
            Assert.IsTrue(output.Contains(expectedOutput));
        }
    }
}
