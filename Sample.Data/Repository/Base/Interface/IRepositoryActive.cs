using Sample.Model.Base;
using System.Linq;

namespace Sample.Data.Repository.Base.Interface
{
 public   interface IRepositoryActive<T>: IRepositoryTyped<T>
        where T : EntityActive
    {
        IQueryable<T> GetTrash();
    }
}
