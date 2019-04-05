using DomainMap.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainMap
{
   public class Events
    {
        [Key, Column(Order = 0)]
        public int EventId { get; set; }

        public String Subject { get; set; }

        public String Description { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public String Themecolor { get; set; }

        public Byte IsFullDay { get; set; }
        
    }
}
