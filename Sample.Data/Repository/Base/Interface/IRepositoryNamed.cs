using Sample.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Data.Repository.Base.Interface
{
    public interface IRepositoryNamed<T> : IRepositoryActive<T>
         where T : EntityNamed
    {
        IQueryable<T> GetNameSearch(string search);

        IQueryable<T> GetList();
    }
}
