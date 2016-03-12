using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Model.Base;
using Sample.Model.Dto;

namespace Sample.Service.Base.Interface
{
    public interface IDataService<T> : IService
        where T : Entity
    {
         int RecordsPerPage { get; }

        Task<T> GetAsync(int id);
        Task<List<T>> GetAsync();

        Task<T> SaveAsync(T model);

        Task<bool> DeleteAsync(T model);
        ActionStateDto CreatePostActionState(T entity);
        ActionStateDto CreateDeleteActionState(bool deleteActionState, int? entityId);
    }
}
