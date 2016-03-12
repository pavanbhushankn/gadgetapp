using Sample.Model.Base;
using Sample.Service.Base.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;






namespace Sample.WebApi.ApiController.Base
{
    public class EntityApiController<T> : System.Web.Http.ApiController
       where T : Entity
    {
        private readonly IDataService<T> _dataService;

        public EntityApiController(IDataService<T> dataService)
        {
            this._dataService = dataService;
        }


        public virtual async Task<IHttpActionResult> Get(int id)
        {
            var entity = await _dataService.GetAsync(id);

            return (entity == null) ? (IHttpActionResult)NotFound() : Ok(entity);
        }

        public virtual async Task<IHttpActionResult> Get()
        {
            var entity = await _dataService.GetAsync();

            return (entity == null) ? (IHttpActionResult)NotFound() : Ok(entity);


        }


        [HttpPost]
        public virtual async Task<IHttpActionResult> Post([FromBody] T model)
        {
            var savedEntityTask = await _dataService.SaveAsync(model);

            var savedConfirmation = savedEntityTask != null
                ? ActionConfirmation.CreateSuccessConfirmation(savedEntityTask)
                : ActionConfirmation.CreateFailureConfirmation("Unable to save entity.");
            if (savedConfirmation.WasSuccessful)
            {
                return this.Ok(savedConfirmation.Value);
            }

            return this.InternalServerError();

        }


        [HttpDelete]
        public virtual async Task<IHttpActionResult> Delete([FromBody] T entity)
        {
            var deletedEntityTask = await _dataService.DeleteAsync(entity);
            var deleteConfirmation = deletedEntityTask
               ? ActionConfirmation.CreateSuccessConfirmation(entity)
               : ActionConfirmation.CreateFailureConfirmation("Unable to delete entity.");

            if (deleteConfirmation.WasSuccessful)
            {
                return this.Ok(deleteConfirmation.Value);
            }

            return this.InternalServerError();
        }
    }

}