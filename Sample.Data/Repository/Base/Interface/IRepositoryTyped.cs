using Sample.Model.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample.Data.Repository.Base.Interface
{
   public interface IRepositoryTyped<T>: IRepository where T : Entity
    {
        Task<T> GetAsync(int id);

        Task<List<T>> GetAsync();

        Task<T> SaveAsync(T entity);

        Task<bool> DeleteAsync(T entity);
    }
}
