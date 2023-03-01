using GolPredictor.WebApi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GolPredictor.WebApi.DataAccess.Repositories.Contracts
{
    internal interface ISesionRepository
    {
        Sesion Find(Expression<Func<Sesion, bool>> expression);
        void Insert(Sesion sesion);
        IEnumerable<Sesion> List();
        IEnumerable<Sesion> List(Expression<Func<Sesion, bool>> expression);
        void Update(Sesion sesion);
    }
}