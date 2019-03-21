using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Task

    {
        public int TaskId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime DeadLine { get; set; }
        public String Name { get; set; }
        public String Status { get; set; }

       public virtual ICollection<History>Histories { get; set; }


    }
}
