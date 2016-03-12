using Sample.Model.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Data
{
   public class ProductDbContext : DbContext
    {
        public ProductDbContext()
            :base("name=Products.ConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProductDbContext, Migrations.Configuration>("Products.ConnectionString"));
        }

        public ProductDbContext(DbConnection connection)
            :base(connection, true)
        {

        }

        public virtual IDbSet<Laptop> Laptops { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Laptop>()
                .Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Laptop>()
                .Property(t => t.Brand)
                .IsUnicode(false);
            modelBuilder.Entity<Laptop>()
                .Property(t => t.Company)
                .IsUnicode(false);
            modelBuilder.Entity<Laptop>()
                .Property(t => t.Price);
                
        }
    }
}
