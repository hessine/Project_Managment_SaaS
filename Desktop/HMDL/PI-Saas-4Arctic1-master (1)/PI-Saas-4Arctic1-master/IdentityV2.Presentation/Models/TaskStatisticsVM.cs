using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityV2.Presentation.Models
{
    public class TaskStatisticsVM
    {
        public int nnbTotalTasks { get; set; }



        public int nbrTaskToDo { get; set; }
        public int nbrTaskDoing { get; set; }
        public int nbrTaskDone { get; set; }

        public int nbrTaskFinishEarly { get; set; }


    }
    
}