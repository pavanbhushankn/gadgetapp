using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Data.Repository.Base;
using Sample.Data.Repository.Base.Interface;
using Sample.Model.Base;
namespace Sample.Data.Repository.Base
{
    class EfRepositoryNamed<T> : EFRepositoryActive<T>, IRepositoryNamed<T>
        where T : EntityNamed
    {


        public EfRepositoryNamed(IContextProvider<ProductDbContext> contextProvider)
            : base(contextProvider)
        {

        }
        public IQueryable<T> GetList()
        {
            return this.Table.Where(e => e.IsActive);
        }

        public IQueryable<T> GetNameSearch(string search)
        {
            return this.Table.Where(e => e.Name == search && e.IsActive);
        }
    }
}
