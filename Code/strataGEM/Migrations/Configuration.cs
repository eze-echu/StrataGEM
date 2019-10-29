namespace strataGEM.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using strataGEM.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<strataGEM.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "strataGEM.Models.ApplicationDbContext";
        }

        protected override void Seed(strataGEM.Models.ApplicationDbContext context)
        {
            IDbSet<Account> a = (IDbSet<Account>)context.Accounts;
            a.AddOrUpdate<Account>(account => account.Name,
                new Account { Name = "Account1" },
                new Account { Name = "Account2" },
                new Account { Name = "Account3" });
            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
    
}
