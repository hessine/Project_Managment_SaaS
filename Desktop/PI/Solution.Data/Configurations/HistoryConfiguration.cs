using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data.Configurations
{
    class HistoryConfiguration : EntityTypeConfiguration<History>
    {
        public HistoryConfiguration()
        {
            HasRequired(f => f.task).WithMany(p => p.Histories)
                .HasForeignKey(f => f.TaskId)
                .WillCascadeOnDelete(true);
        }

    }
}
