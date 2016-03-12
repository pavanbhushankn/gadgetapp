using Sample.Model.Core;
using Sample.Model.Dto;
using Sample.Service.Base.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Service.Core.Interface
{
    public interface ILaptopService:IDataService<Laptop>
    {
        Task<List<Laptop>> Get();
        Task<Laptop> Get(int id);

        Task<ActionStateDto> Post(Laptop dto);

        Task<ActionStateDto> Delete(Laptop dto);
    }
}
