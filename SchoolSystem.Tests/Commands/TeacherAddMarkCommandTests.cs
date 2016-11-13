using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Models.Contracts;

namespace SchoolSystem.Tests.Commands
{
    [TestFixture]
    public class TeacherAddMarkCommandTests
    {
        [Test]
        public void Execute_ShouldCallAddMarksMethodOnFoundStudent()
        {
            //Arrange
            var mockDatabase = new Mock<IDatabase>();

            var command = new TeacherAddMarkCommand(mockDatabase.Object);

            var fakeCommand = new List<string> { "0", "0", "6" };

            var mockTeacher = new Mock<ITeacher>();
            var mockStudent = new Mock<IStudent>();
            mockDatabase.Setup(x => x.Teachers[It.IsAny<int>()]).Returns(mockTeacher.Object);
            mockDatabase.Setup(x => x.Students[It.IsAny<int>()]).Returns(mockStudent.Object);

            //Act
            command.Execute(fakeCommand);

            //Assert
            mockTeacher.Verify(x => x.AddMark(It.IsAny<IStudent>(), It.IsAny<float>()));
        }

        [Test]
        public void Execute_ShouldReturnCorrentMessage_WhenMarkAddedCorrectly()
        {
            //Arrange
            var mockDatabase = new Mock<IDatabase>();

            var command = new TeacherAddMarkCommand(mockDatabase.Object);

            var fakeCommand = new List<string> { "0", "0", "6" };

            var mockTeacher = new Mock<ITeacher>();
            var mockStudent = new Mock<IStudent>();
            mockDatabase.Setup(x => x.Teachers[It.IsAny<int>()]).Returns(mockTeacher.Object);
            mockDatabase.Setup(x => x.Students[It.IsAny<int>()]).Returns(mockStudent.Object);

            var expectedContains = "added mark";

            //Act
            var output = command.Execute(fakeCommand);

            //Assert
            StringAssert.Contains(expectedContains, output);
        }
    }
}
