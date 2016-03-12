using Sample.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Service.Base;
using Sample.Model.Core;
using Sample.Service.Core.Interface;
using Sample.Model.Dto;
using Sample.Data.Repository.Core.Interface;

namespace Sample.Service.Core
{
    public class LaptopService : DataService<Laptop>, ILaptopService
    {

        public LaptopService(ILaptopRepository repository)
            :base(repository)
        {

        }

        public virtual async Task<ActionStateDto> Delete(Laptop dto)
        {
            var returnValue = await base.DeleteAsync(dto);

            return await Task.Factory.StartNew(() => base.CreateDeleteActionState(returnValue,1));
        }

        public virtual async Task<List<Laptop>> Get()
        {
            var queryItemns = await base.GetAsync();

            return queryItemns.Where(r => r.IsActive)
                .OrderByDescending(r => r.LastModifiedOn)
               .ToList();
        }

        public virtual async Task<Laptop> Get(int id)
        {
            var laptop = await base.GetAsync(id);
            return laptop;
        }

        public virtual async Task<ActionStateDto> Post(Laptop dto)
        {
            var returnValue = await base.SaveAsync(dto);

            return await Task.Factory.StartNew(() => base.CreatePostActionState(returnValue));
        }
    }
}
