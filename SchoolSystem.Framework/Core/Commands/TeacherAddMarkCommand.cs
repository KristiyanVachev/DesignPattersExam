using System.Collections.Generic;

using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Factories;

namespace SchoolSystem.Framework.Core.Commands
{
    public class TeacherAddMarkCommand : ICommand
    {
        private IDatabase database;
        private ISchoolFactory schoolFactory;

        public TeacherAddMarkCommand(ISchoolFactory schoolFactory, IDatabase database)
        {
            this.database = database;
            this.schoolFactory = schoolFactory;
        }

        public string Execute(IList<string> parameters)
        {
            var teacherId = int.Parse(parameters[0]);
            var studentId = int.Parse(parameters[1]);
            var mark = float.Parse(parameters[2]);

            var student = this.database.Students[studentId];
            var teacher = this.database.Teachers[teacherId];

            var newMark = schoolFactory.CreateaMark(teacher.Subject, mark);

            teacher.AddMark(student, newMark);
            return $"Teacher {teacher.FirstName} {teacher.LastName} added mark {mark} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
        }
    }
}
