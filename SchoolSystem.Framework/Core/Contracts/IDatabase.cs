using System.Collections.Generic;
using SchoolSystem.Framework.Models.Contracts;

namespace SchoolSystem.Framework.Core.Contracts
{
    public interface IDatabase
    {
        IDictionary<int, ITeacher> Teachers { get; }

        IDictionary<int, IStudent> Students { get; }
    }
}
