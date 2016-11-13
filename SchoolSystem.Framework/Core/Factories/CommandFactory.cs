using System;
using System.Reflection;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Framework.Core.Factories
{
    public class CommandFactory : ICommandFactory
    {
        public ICommand GetCommand(TypeInfo commandTypeInfo, ISchoolFactory factory, IDatabase database)
        {
            ICommand command;

            switch (commandTypeInfo.Name)
            {
                case "CreateStudentCommand":
                case "CreateTeacherCommand":
                case "TeacherAddMarkCommand":
                    command = Activator.CreateInstance(commandTypeInfo, factory, database) as ICommand;
                    break;
                default:
                    command = Activator.CreateInstance(commandTypeInfo, database) as ICommand;
                    break;
            }

            return command;



        }
    }
}
