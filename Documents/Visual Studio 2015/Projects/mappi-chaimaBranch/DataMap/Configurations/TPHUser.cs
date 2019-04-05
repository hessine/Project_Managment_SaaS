using DomainMap.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMap.Configurations
{
   public class TPHUser: EntityTypeConfiguration<User>
    {
        public TPHUser()
        {
            Map<Client>(c => c.Requires("Type").HasValue(0));

            Map<Resource>(c => c.Requires("Type").HasValue(1));

            Map<Applicant>(c => c.Requires("Type").HasValue(2));
        }
    }
}
