using Sample.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Service.Base.Interface
{
  public  interface IActiveService<T> : IDataService<T>
        where T : EntityActive
    {

    }
}
