using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCConsumeWebApi.Models
{
    public class Project
    {

        public int ProjectId { get; set; }
        public String Name { get; set; }

        public DateTime DateBegin { get; set; }

        public DateTime DateEnd { get; set; }

        public string Description { get; set; }

        public int TotalNbrRessources { get; set; }
    }
}