using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Data.Repository.Base.Interface;
using Sample.Model.Base;
using System.Data.Entity;

namespace Sample.Data.Repository.Base
{
    public class EfRepositoryBase<T> : IRepositoryTyped<T>
         where T : Entity

    {


        private readonly IContextProvider<ProductDbContext> contextProvider;

        public EfRepositoryBase(IContextProvider<ProductDbContext> contextProvider)
        {
            this.contextProvider = contextProvider;
            this.Table = this.Context.Set<T>();
        }

        protected virtual ProductDbContext Context => this.contextProvider.Context;
        protected virtual IDbSet<T> Table { get; set; }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            var entityDeleted = true;

            try
            {
                var e = this.Context.Entry(entity);
                if (e.State == EntityState.Detached)
                {
                    this.Context.Set<T>().Attach(entity);
                    e = this.Context.Entry(entity);
                }

                e.State = EntityState.Deleted;
                await this.Context.SaveChangesAsync();

            }
            catch (Exception)
            {

                entityDeleted =  false;
            }

            return Task<bool>.Factory.StartNew(() => entityDeleted).Result;
        }

        public virtual async Task<List<T>> GetAsync()
        {
            return await this.Table.ToListAsync();
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await this.Table.FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<T> SaveAsync(T entity)
        {
            entity.LastModifiedOn = DateTime.Now;
            if (entity.Id > 0)
            {
                this.Context.Entry(entity).State = EntityState.Modified;
            }

            else
            {
                if (entity is EntityActive)
                {
                    (entity as EntityActive).IsActive = true;
                    (entity as EntityActive).Intrash = false;
                }

                entity.CreatedOn = DateTime.Now;
                entity = this.Table.Add(entity);
                entity.LastModifiedBy = -1;

            }

            try
            {
                await this.Context.SaveChangesAsync();
            }
            catch (Exception)
            {
               
                entity = null;
            }
            var savedEntity = Task<T>.Factory.StartNew(() => entity);
            return savedEntity.Result;
        }
    }
}
