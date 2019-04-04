using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data.Configurations
{
    public class HistoryConfiguration : EntityTypeConfiguration<History>
    {
        public HistoryConfiguration()
        {
            HasRequired(f => f.taskPM).WithMany(p => p.Histories)
                .HasForeignKey(f => f.TaskId)
                .WillCascadeOnDelete(true);
        }

    }
}
