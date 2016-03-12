using Sample.Data.Repository.Base.Interface;
using System.Data.Entity;
using System;

namespace Sample.Data.Repository.Base
{
    public sealed class ContextProvider<TDbContext> : IContextProvider<TDbContext>
        where TDbContext : DbContext
    {
        public TDbContext Context
        {
            get;
        }

        public ContextProvider(TDbContext context)
        {
            this.Context = context;
        }
    }
}
