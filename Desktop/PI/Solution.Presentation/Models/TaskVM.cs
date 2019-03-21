using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Solution.Presentation.Models
{
    public class TaskVM
    {

        public int TaskId { get; set; }

        [DataType(DataType.Date)]//affichi calendrier

        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]//affichi calendrier

        public DateTime EndDate { get; set; }

        [DataType(DataType.Date)]//affichi calendrier

        public DateTime DeadLine { get; set; }


        public String Name { get; set; }
        public String Status { get; set; }
    }
}