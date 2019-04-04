using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdentityV2.Presentation.Models
{
    public class TaskPMVM
    {
        public int TaskId { get; set; }

        [DataType(DataType.Date)]//affichi calendrier

        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]//affichi calendrier

        public DateTime EndDate { get; set; }

        [DataType(DataType.Date)]//affichi calendrier

        public DateTime DeadLine { get; set; }

        [Display(Name = "Task Name")]

        public String Name { get; set; }
        public String Status { get; set; }

        [Display(Name = "Project Name")]

        public int ProjectId { get; set; }
        public IEnumerable<SelectListItem> Projects { get; set; }
        public string ProjectName { get; set; }

    }
}