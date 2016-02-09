using LayeredApplication.Model;
using System;
using System.Collections.Generic;

namespace LayeredApplication.DataLayer.Infrastructure.Repository
{
    public interface IContext<TEntity> where TEntity : IVehicleEntity
    {
        //change - ddl
        TEntity Add(TEntity entity);
        bool Update(TEntity entity);
        bool Remove(TEntity entity);

        //fetch - dml
        TEntity Get(int id);
        List<TEntity> Find(Func<TEntity, bool> predicate);
        List<TEntity> GetAll();
    }
}
