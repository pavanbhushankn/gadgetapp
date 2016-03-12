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
    public class NamedService<T> : ActiveService<T>, INamedService<T>
        where T : EntityNamed
    {
        private readonly IRepositoryNamed<T> repository;
        public NamedService(IRepositoryNamed<T> repository)
           : base(repository)
        {
            this.repository = repository;
        }

        public virtual IQueryable<T> GetNameList()
        {
            return this.repository.GetList();
        }

        public virtual IQueryable<T> GetNameSearch(string search)
        {
            return this.repository.GetNameSearch(search);
        }
    }
}
