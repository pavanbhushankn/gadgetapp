using Sample.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Service.Base.Interface
{
   public interface INamedService<T>: IActiveService<T>
        where T :  EntityNamed
    {

        IQueryable<T> GetNameSearch(string search);
        IQueryable<T> GetNameList();
    }
}
