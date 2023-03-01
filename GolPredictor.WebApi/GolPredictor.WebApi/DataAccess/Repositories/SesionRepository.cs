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
    class SesionRepository : ISesionRepository
    {
        #region Fields
        protected readonly GoalPredictorDbContext _context;
        #endregion

        #region Builders

        public SesionRepository(GoalPredictorDbContext context)
        {
            _context = context;
        }
        #endregion


        #region Methods
        public Sesion Find(Expression<Func<Sesion, bool>> expression)
        {
            return _context.Set<Sesion>().AsNoTracking().FirstOrDefault(expression);
        }

        public IEnumerable<Sesion> List(Expression<Func<Sesion, bool>> expression)
        {
            return _context.Set<Sesion>().Include(s => s.SesionUsuario).Include(s=> s.Partido).AsNoTracking().Where(expression).ToList();
        }
        public IEnumerable<Sesion> List()
        {
            return _context.Set<Sesion>().Include(s=> s.SesionUsuario).Include(s => s.Partido).AsNoTracking().ToList();
        }

        public void Insert(Sesion sesion)
        {
            _context.Sesion.Add(sesion);
            _context.SaveChanges();            
        }

        public void Update(Sesion sesion)
        {
            var originalPartido = _context.Partido.FirstOrDefault(x => x.Id == sesion.Id);
            FrammeworkTypeUtility.SetProperties(sesion, originalPartido);
            _context.SaveChanges();
        }
        #endregion

    }
}
