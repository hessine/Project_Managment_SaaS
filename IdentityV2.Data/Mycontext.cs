using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityV2.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityV2.Data
{
    public class MyContext : IdentityDbContext<User>//
    {

        public MyContext() : base("manel")
        {
            Database.SetInitializer(new ContexInit());
        }


        public static MyContext Create()
        {
            return new MyContext();
        }

        // dbset
        public DbSet<TaskPM> Tasks { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Project> Projects { get; set; }
      //  public DbSet<Category> Categories { get; set; }
       // public DbSet<Document> Documents { get; set; }


        public System.Data.Entity.DbSet<IdentityV2.Domain.Entities.Company> Companies { get; set; }

        // dbset

        /* public DbSet<Company> Companies { get; set; }
        */

    }


    public class ContexInit : DropCreateDatabaseIfModelChanges<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            /*   List<Patient> patients = new List<Patient>() {
                   new Patient {PatientId=1
                               }

               };
               context.Patients.AddRange(patients);
               context.SaveChanges();*/
        }
    }
}
