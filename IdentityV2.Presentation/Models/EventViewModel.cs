using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace IdentityV2.Presentation.Models
{
    public class EventViewModel
    {
        public int EventId { get; set; }

        public String Subject { get; set; }

        public String Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime Start { get; set; }
        [DataType(DataType.Date)]
        public DateTime End { get; set; }
        public String Themecolor { get; set; }

        public Byte IsFullDay { get; set; }
       
    }
}