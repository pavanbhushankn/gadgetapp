namespace Sample.Data.Migrations
{
    using Model.Core;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Sample.Data.ProductDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Sample.Data.ProductDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Laptops.AddOrUpdate(
                
               new Laptop {

                   Id =  1,
                   CreatedBy = -1,
                   CreatedOn = DateTime.Now,
                   Intrash = false,
                   IsActive = true,
                   LastModifiedBy = null,
                   
                   Company ="IBM",
                   Brand="ThinkPad",
                   Price=25000

               },
                new Laptop
                {

                    Id = 2,
                    CreatedBy = -1,
                    CreatedOn = DateTime.Now,
                    Intrash = false,
                    IsActive = true,
                    LastModifiedBy = null,

                    Company = "Hp",
                    Brand = "ThinkPad",
                    Price = 29500

                },
                new Laptop
                {

                    Id = 3,
                    CreatedBy = -1,
                    CreatedOn = DateTime.Now,
                    Intrash = false,
                    IsActive = true,
                    LastModifiedBy = null,
                    Company = "Lenovo",
                    Brand = "Elite",
                    Price = 29500

                }


                );
            context.SaveChanges();
            
        }
    }
}
