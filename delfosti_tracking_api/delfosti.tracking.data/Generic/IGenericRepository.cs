using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delfosti.tracking.data.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Int32 id);
        Task<Boolean> Update(T entity);
        Task<Boolean> Insert(T entity);
        Task<Boolean> Delete(Int32 id);
    }
}
