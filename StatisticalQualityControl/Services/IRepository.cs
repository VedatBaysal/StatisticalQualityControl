using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatisticalQualityControl.Models;

namespace StatisticalQualityControl.Services
{
    internal interface IRepository<T> where T : EntityObject
    {
        bool Add(T entity);
        int AddRange(IEnumerable<T> entities);
        bool Delete(T entity);
        bool Update(T entity);
        IEnumerable<T> GetAll();
        T GetById(int id);
        T GetRandomElement();
    }
}
