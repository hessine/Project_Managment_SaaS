using Solution.Data.Configurations;
using Solution.Data.CustomConventions;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data
{
    public class MyContext : DbContext
    {

       public MyContext():base("name=machaine")
        {

        }
        // dbset
        public DbSet<Domain.Entities.Task> Films { get; set; }
        public DbSet <History> Producers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new HistoryConfiguration());
            modelBuilder.Conventions.Add(new DateTime2Convention());

            //modelBuilder.Conventions.Add();

        }
    }
}
