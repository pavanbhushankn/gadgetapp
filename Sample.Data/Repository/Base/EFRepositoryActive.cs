using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Data.Repository.Base.Interface;
using Sample.Data.Repository.Base;
using Sample.Model.Base;
namespace Sample.Data.Repository
{
    public class EFRepositoryActive<T> : EfRepositoryBase<T>, IRepositoryActive<T>
         where T : EntityActive
    {

        public EFRepositoryActive(IContextProvider<ProductDbContext> contextProvider)
            :base(contextProvider)
        {
            
        }


        public IQueryable<T> GetTrash()
        {
            return this.Table.Where(e => e.Intrash);
        }
    }
}
