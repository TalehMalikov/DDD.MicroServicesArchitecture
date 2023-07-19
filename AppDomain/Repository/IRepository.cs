using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomain.Repositories
{
    public interface IRepository <T> where T : class
    {
        Task<List<T>> GetListAsync();

        Task<T> GetAsync(Guid id);

        Task<T> InsertAsync(T todoItem);

        Task<T> UpdateAsync(Guid id, T todoItem);

        Task DeleteAsync(Guid id);
    }
}
