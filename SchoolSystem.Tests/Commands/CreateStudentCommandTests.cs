using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Factories;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Tests.Commands
{
    [TestFixture]
    public class CreateStudentCommandTests
    {
        [Test]
        public void Execute_ShouldCallFactoryWithProperMethod_WhenInputIsValid()
        {
            //Arrange
            var mockSchoolFactory = new Mock<ISchoolFactory>();
            var mockDatabase = new Mock<IDatabase>();

            CreateStudentCommand command = new CreateStudentCommand(mockSchoolFactory.Object, mockDatabase.Object);
            var fakeCommand = new List<string> { "Harry", "Potter", "6" };

            mockSchoolFactory.Setup(x => x.CreateStudent(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Grade>())).Returns(It.IsAny<IStudent>());

            mockDatabase.Setup(x => x.Students.Add(It.IsAny<int>(), It.IsAny<IStudent>()));

            //Act
            command.Execute(fakeCommand);

            //Assert
            mockSchoolFactory.Verify(s => s.CreateStudent(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Grade>()));
        }

        [Test]
        public void Execute_ReturnsProperMessage_WhenInputIsValid()
        {
            //Arrange
            var mockSchoolFactory = new Mock<ISchoolFactory>();
            var mockDatabase = new Mock<IDatabase>();

            CreateStudentCommand command = new CreateStudentCommand(mockSchoolFactory.Object, mockDatabase.Object);
            var fakeCommand = new List<string> { "Harry", "Potter", "6" };
            //var fakeEnum = (Grade)Enum.Parse(typeof(Grade), "6", true);

            mockSchoolFactory.Setup(x => x.CreateStudent(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<Grade>())).Returns(It.IsAny<IStudent>());

            mockDatabase.Setup(x => x.Students.Add(It.IsAny<int>(), It.IsAny<IStudent>()));

            var expectedOutput ="A new student with name Harry Potter, grade Sixth and ID";

            //Act
            string output = command.Execute(fakeCommand);

            //Assert
            Assert.IsTrue(output.Contains(expectedOutput));
        }

    }
}
