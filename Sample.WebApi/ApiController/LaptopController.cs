using Sample.Model.Core;
using Sample.WebApi.ApiController.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sample.Service.Base.Interface;
using Sample.Service.Core.Interface;
using System.Web.Http;
using System.Threading.Tasks;
using Sample.Model.Dto;

namespace Sample.WebApi.ApiController
{
    [RoutePrefix("api/laptop")]
    public class LaptopController : EntityApiController<Laptop>
    {

        private readonly ILaptopService laptopService;
        public LaptopController(ILaptopService LaptopService) 
            : base(LaptopService)
        {
            this.laptopService = LaptopService;
        }


        [Route(""), HttpGet]
        public override  async Task<IHttpActionResult> Get()


        {
            var data= await laptopService.Get();

            return (data == null) ? (IHttpActionResult)NotFound() : Ok(data);
        }

        [Route("{id:int}"), HttpGet]
        public override async Task<IHttpActionResult> Get(int id)
        {
            var data = await laptopService.Get(id);

            return (data == null) ? (IHttpActionResult)NotFound() : Ok(data);
        }

        [Route("Create"), HttpPost]
        public override async Task<IHttpActionResult> Post([FromBody] Laptop dto)
        {
            if (dto == null) return BadRequest(ModelState);

            ActionStateDto actionStateDto;

            try
            {
                actionStateDto = await laptopService.Post(dto);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

            return Ok(actionStateDto);
        }
        [Route(""), HttpDelete]
        public override  async Task<IHttpActionResult> Delete([FromBody] Laptop dto)
        {
            if (dto == null) return BadRequest(ModelState);
            ActionStateDto actionStateDto;

            try
            {
                actionStateDto = await laptopService.Delete(dto);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
              
            }

            return Ok(actionStateDto);
        }


    }
}