using StatisticalQualityControl.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using StatisticalQualityControl.Models;
using static StatisticalQualityControl.Services.SingletonRandom;
using static StatisticalQualityControl.Services.SingletonDbModel;

namespace StatisticalQualityControl.Facade
{
    public class Crud<T> : IRepository<T> where T : EntityObject
    {
        private readonly DbSet<T> _table;

        public Crud()
        {
            _table = Db.Set<T>();
        }

        public StatisticalQualityControlModel GetDbContext()
        {
            return Db;
        }

        public bool Add(T entity)
        {
            _table.Add(entity);
            var count = Db.SaveChanges();
            return count > 0;

        }

        public int AddRange(IEnumerable<T> entities)
        {
            _table.AddRange(entities);
            var count = Db.SaveChanges();
            return count;
        }

        public bool Delete(T entity)
        {
            _table.Remove(entity);
            var count = Db.SaveChanges();
            return count > 0;
        }

        public IEnumerable<T> GetAll()
        {
            return _table;
        }

        public T GetById(int id)
        {
            return _table.FirstOrDefault(x => x.id == id);
        }

        public bool Update(T entity)
        {
            Db.Entry(entity).State = EntityState.Modified;
            var count = Db.SaveChanges();
            return count > 0;
        }
        public T GetRandomElement()
        {
            var elementCount = _table.Count();

            var rndElement = Rnd.Next(0, elementCount);

            var selectedElement = _table.OrderBy(x => x.id).Skip(rndElement).FirstOrDefault();
            return selectedElement;
        }
    }
}