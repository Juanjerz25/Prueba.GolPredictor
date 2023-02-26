using GolPredictor.WebApi.DataAccess.Entities;
using GolPredictor.WebApi.DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GolPredictor.WebApi.DataAccess.Repositories
{
    class UserAdminRepository: IUserAdminRepository
    {
        #region Fields
        protected readonly GoalPredictorDbContext _context;
        #endregion

        #region Builders

        public UserAdminRepository(GoalPredictorDbContext context)
        {
            _context = context;
        }
        #endregion


        public IEnumerable<UserAdmin> List(Expression<Func<UserAdmin, bool>> expression)
        {
            return _context.Set<UserAdmin>().Where(expression).AsNoTracking();
        }
    }
}
