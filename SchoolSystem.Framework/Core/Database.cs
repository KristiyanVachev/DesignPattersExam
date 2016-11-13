using System.Collections.Generic;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Models.Contracts;

namespace SchoolSystem.Framework.Core
{
    public class Database : IDatabase
    {
        private int studentIdCount = 0;
        private int teacherIdCount = 0;

        private Dictionary<int, ITeacher> teachers = new Dictionary<int, ITeacher>();
        private Dictionary<int, IStudent> students = new Dictionary<int, IStudent>();


        public IDictionary<int, ITeacher> Teachers
        {
            get { return this.teachers; }
        }

        public IDictionary<int, IStudent> Students
        {
            get { return this.students; }
        }
    }
}
