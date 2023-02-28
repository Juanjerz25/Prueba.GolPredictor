using GolPredictor.WebApi.DataAccess.Entities;
using GolPredictor.WebApi.DataAccess.Repositories.Contracts;
using GolPredictor.WebApi.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GolPredictor.WebApi.DataAccess.Repositories
{
    class PaisRepository : IPaisRepository
    {
        #region Fields
        protected readonly GoalPredictorDbContext _context;
        #endregion

        #region Builders

        public PaisRepository(GoalPredictorDbContext context)
        {
            _context = context;
        }
        #endregion


        #region Methods

        public IEnumerable<Pais> List()
        {
            return _context.Set<Pais>().AsNoTracking().OrderBy(x=> x.Nombre).ToList();
        }

        #endregion

    }
}
