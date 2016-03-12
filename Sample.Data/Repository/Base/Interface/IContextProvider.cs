using System.Data.Entity;

namespace Sample.Data.Repository.Base.Interface
{
    public interface IContextProvider<out TDbContext>
        where TDbContext : DbContext
    {

        TDbContext Context { get;}
    }
}
