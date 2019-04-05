using DataMap.Configurations;
using DataMap.Conventions;
using DomainMap;
using DomainMap.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMap
{
   public class MyContext : IdentityDbContext<User, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public static MyContext Create()
        {
            return new MyContext();
        }
        static MyContext()
        {
            Database.SetInitializer<MyContext>(null);
        }
        public MyContext() : base("name=MapDb")
        {
            TPHUser tphu = new TPHUser();
            ResourceConfiguration rc = new ResourceConfiguration();
            Date2timeConvention dt = new Date2timeConvention();
          //  SkillsConfiguration sc = new SkillsConfiguration();
        }
        public DbSet<Project> project { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Mandate> mandate { get; set; }
        public DbSet<Demands> demand { get; set; }
        public DbSet<File> file { get; set; }
        public DbSet<Test> test { get; set; }
        public DbSet<Events> events { get; set; }
        public DbSet<Resource> resources { get; set; }
        public DbSet<Documents> documents { get; set; }
        public DbSet<Skills> skills { get; set; }
        public DbSet<Skillsofproject> skillsofproject { get; set; }
        public DbSet<HistoricalMandate> historicalMandate { get; set; }
        public DbSet<resourceSkills> ResourceSkills { get; set; }

        // public DbSet<ApplicationUser> user { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           modelBuilder.Configurations.Add(new TPHUser());
          //  modelBuilder.Configurations.Add(new SkillsConfiguration());
            modelBuilder.Configurations.Add(new RequestConfiguration());
            modelBuilder.Configurations.Add(new ProjectCategoryConfiguration());
            //modelBuilder.Configurations.Add(new ResourceConfiguration());
            modelBuilder.Conventions.Add(new Date2timeConvention());
        }
    }
}

