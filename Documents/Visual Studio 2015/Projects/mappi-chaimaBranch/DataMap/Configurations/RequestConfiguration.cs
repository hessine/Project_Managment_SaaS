using DomainMap.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;

namespace DataMap.Configurations
{
    public class RequestConfiguration: EntityTypeConfiguration <Request>
    {
      public RequestConfiguration()
        {
            HasRequired<Client>(t => t.client).WithMany(t => t.listRequest).HasForeignKey(t => t.ClientId).WillCascadeOnDelete(true);

       }
    }
}
