using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityV2.Domain.Entities
{
    public    class TaskPM
    {
        [Key, Column(Order = 0)]
        
        public int TaskId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DeadLine { get; set; }
        public String Name { get; set; }
        public String Status { get; set; }




        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
       // public virtual Project Project { get; set; }
        public virtual ICollection<History> Histories { get; set; }

    }
}
