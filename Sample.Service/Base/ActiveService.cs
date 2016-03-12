using Sample.Data.Repository.Base.Interface;
using Sample.Model.Base;
using Sample.Service.Base.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Service.Base
{
    public class ActiveService<T> : DataService<T>, IActiveService<T>
        where T : EntityActive
    {

        private readonly IRepositoryActive<T> repository;
        public ActiveService(IRepositoryActive<T> repository)
           : base(repository)
        {
            this.repository = repository;
        }

    }
}
