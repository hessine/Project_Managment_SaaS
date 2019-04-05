using DomainMap.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMap.Configurations
{
  public  class SkillsConfiguration: EntityTypeConfiguration<Skills>
    {
        //public SkillsConfiguration()
        //{
        //    HasMany<Resource>(a => a.ResourceSkills).WithMany(t => t.ResourceSkills).Map(
        //        r =>
        //        {
        //            r.ToTable("ResourceSkills");
        //            r.MapLeftKey("SkillsId");
        //            r.MapRightKey("ResourceId"); 

        //        });
        //    HasMany<Project>(a => a.ProjectSkills).WithMany(t => t.ProjectSkills).Map(
        //        r =>
        //        {
        //            r.ToTable("ProjectSkills");
        //            r.MapLeftKey("SkillsId");
        //            r.MapRightKey("ProjectId"); 
        //        }

        //        );
        //}
        
    }
}
