using System.Collections.Generic;
using StarWars.Infrastructure.Model;

namespace StarWarsKb.Back.Model
{
    public interface IBaseRepository<T> where T : IStarWarsEntity
    {
        IList<T> GetAll();
        T GetById(int id);
        void Save(T entity);
        void Save(IList<T> entities);
    }
}