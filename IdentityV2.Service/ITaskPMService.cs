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
        IEnumerable<TaskPM> GetTaskPMavailable();
        IEnumerable<TaskPM> GetTaskPMWaiting();
        IEnumerable<TaskPM> SearchTasks(string ch);

        IEnumerable<TaskPM> USERbyRole();

      
        IEnumerable<TaskPM> GetTaskPMToDo();
        IEnumerable<TaskPM> GetTaskPMDoing();
        IEnumerable<TaskPM> GetTaskPMDone();


    }
}
