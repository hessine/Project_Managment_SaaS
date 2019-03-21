using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solution.Presentation.Models
{
    public class HistoryVM
    {

        public int HistoryId { get; set; }
        public String Description { get; set; }


        public int? TaskId { get; set; }
    }
}