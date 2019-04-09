using IdentityV2.Data.Infrastructure;
using IdentityV2.Domain.Entities;
using IdentityV2.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityV2.Service
{
    public interface ITaskPMService : IService<TaskPM>
    {
        IEnumerable<TaskPM> GetTaskPMDone();
        IEnumerable<TaskPM> GetTaskPMDoing();
        IEnumerable<TaskPM> GetTaskPMToDo();

        IEnumerable<TaskPM> SearchTasks(string ch);

        IEnumerable<TaskPM> USERbyRole();

        int  GetTotalTasks();
          int NbTaskByStatusToDo();
        int NbTaskByStatusDoing();
        int NbTaskByStatusDone();
        int FinishTaskEarly();
        IEnumerable<TaskPM> ReturnFinishTaskEarly();
        int nbrTaskInProject();


    }
}
