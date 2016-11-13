using System.Reflection;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;

namespace SchoolSystem.Framework.Core.Factories
{
    public interface ICommandFactory
    {
        ICommand GetCommand(TypeInfo commandTypeInfo, ISchoolFactory factory, IDatabase database);
    }
}
