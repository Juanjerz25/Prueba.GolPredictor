using GolPredictor.WebApi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GolPredictor.WebApi.DataAccess.Repositories.Contracts
{
    interface IUserAdminRepository
    {
        IEnumerable<UserAdmin> List(Expression<Func<UserAdmin, bool>> expression);
    }
}
