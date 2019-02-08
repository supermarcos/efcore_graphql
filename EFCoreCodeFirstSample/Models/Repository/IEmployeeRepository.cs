using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSample.Models.Repository
{
    public interface IEmployeeRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        TEntity Add(TEntity entity);
        TEntity Update(Employee employee, TEntity entity);
        TEntity Delete(Employee employee);
    }
}
