using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityV2.Domain.Entities
{
    public class TaskPM
    {
        [Key, Column(Order = 0)]

        public int TaskId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DeadLine { get; set; }
        public String Name { get; set; }
        public String Status { get; set; }
        public String leader { get; set; }




        public int ProjectId { get; set; }


        public String UserId { get; set; }


        [ForeignKey("UserId")]
        public virtual User User { get; set; }


        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }

        public virtual ICollection<History> Histories { get; set; }
        public virtual ICollection<Comment> ListCommentaire { get; set; }

    }
}
