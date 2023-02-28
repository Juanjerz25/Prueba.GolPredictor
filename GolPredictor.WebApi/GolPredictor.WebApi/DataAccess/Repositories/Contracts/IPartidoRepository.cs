using GolPredictor.WebApi.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GolPredictor.WebApi.DataAccess.Repositories.Contracts
{
    internal interface IPartidoRepository
    {
        Partido Find(Expression<Func<Partido, bool>> expression);
        void Insert(Partido partido);
        IEnumerable<Partido> List(Expression<Func<Partido, bool>> expression);
        IEnumerable<Partido> List();
        void Update(Partido partido);
    }
}