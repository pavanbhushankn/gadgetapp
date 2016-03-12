using Sample.Data.Repository.Base.Interface;
using Sample.Model.Base;
using Sample.Model.Dto;
using Sample.Service.Base.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Service.Base
{
    public class DataService<T> : IDataService<T>
         where T : Entity
    {
        protected readonly IRepositoryTyped<T> _repository;

        public DataService(IRepositoryTyped<T> repository)
        {
            this._repository = repository;

        }
        public virtual int RecordsPerPage => 20;


        public virtual async Task<bool> DeleteAsync(T model)
        {
            return await this._repository.DeleteAsync(model);
        }

        public virtual async Task<List<T>> GetAsync()
        {
            var dataToReturn = await this._repository.GetAsync();
            return dataToReturn.Take(RecordsPerPage).ToList();
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await this._repository.GetAsync(id);
        }

        public virtual async Task<T> SaveAsync(T model)
        {
            return await this._repository.SaveAsync(model);
        }


        public ActionStateDto CreatePostActionState(T entity)
        {
            var actionState = new ActionStateDto {Success= false, Description= $"Couldn't save object of type {typeof(T)} to database." , EntityId= null};

            if (entity == null) return actionState;
            actionState.Success = true;
            actionState.Description = $"Successfully saved entity of type {typeof(T)} to database. New entity id: {entity.Id}";
            actionState.Description = $"Successfully saved entity of type {typeof(T)} to database. New entity id: {entity.Id}";
            actionState.EntityId = entity.Id;

            return actionState;

        }

        public ActionStateDto CreateDeleteActionState(bool deleteActionState, int? entityId)
        {
            var actionState = new ActionStateDto { Success = deleteActionState, Description = $"Failed to delete entity with id {entityId}", EntityId = entityId };

            if (!deleteActionState) return actionState;

            actionState.Success = true;
            actionState.Description = $"Successfully deleted entity with id {entityId}";

            actionState.EntityId = entityId;

            return actionState;

        }
    }
}
