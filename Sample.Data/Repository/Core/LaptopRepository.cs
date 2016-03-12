using Sample.Data.Repository.Base;
using Sample.Data.Repository.Base.Interface;
using Sample.Data.Repository.Core.Interface;
using Sample.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Data.Repository.Core
{
  public  class LaptopRepository: EfRepositoryBase<Laptop>, ILaptopRepository
    {
        private ProductDbContext _context;

        public LaptopRepository(IContextProvider<ProductDbContext> contextProvider)
            :base(contextProvider)
        {
            this._context = contextProvider.Context;
            base.Table = contextProvider.Context.Laptops;


        }

        public override Task<Laptop> SaveAsync(Laptop entity)
        {
            return base.SaveAsync(entity);
        }
    }
}
