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

        [Display(Name = "assign to ")]
        public String User_Id { get; set; }


        public IEnumerable<SelectListItem> Projects { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDesc { get; set; }


        public IEnumerable<SelectListItem> Users { get; set; }

        public string UserName { get; set; }
        //nestha9ouha fil index affichage autre attribut de l id x





        //pour nbr totale de task
        public int nnbTotalTasks { get; set; }

        public int nbrTotalPr { get; set; }

        public int nbrTotalUser { get; set; }
        public int nbrTaskToDo { get; set; }
        public int nbrMyTaskInProject { get; set; }






    }
}