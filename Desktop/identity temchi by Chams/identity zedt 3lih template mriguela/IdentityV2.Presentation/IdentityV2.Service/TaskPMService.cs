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
    public class TaskPMService : Service<TaskPM>, ITaskPMService
    {
        private static IDataBaseFactory dbFac = new DataBaseFactory();
        private static IUnitOfWork wow = new UnitOfWork(dbFac);
        public TaskPMService() : base(wow)
        {
        }

        public IEnumerable<TaskPM> SearchTasks(string ch)
        {
        
            IEnumerable<TaskPM> TaskDomain = GetMany();
            if (!String.IsNullOrEmpty(ch))
            {
                TaskDomain = GetMany(x => x.Name.Contains(ch));
            }
            return TaskDomain;
        




    }

    IEnumerable<TaskPM> ITaskPMService.GetTaskPMavailable()
        {
            return GetMany().OfType<TaskPM>();
        }

        IEnumerable<TaskPM> ITaskPMService.GetTaskPMWaiting()
        {
            throw new NotImplementedException();
        }
    }
    




        /*   IEnumerable<TaskPM> ITaskPMService.GetProjectavailable()
           {
               return GetMany(t => t.Etat == 1).OfType<Project>();
           }*/

        /* IEnumerable<TaskPM> ITaskPMService.GetProjectWaiting()
         {
             return GetMany(t => t.Etat == 0).OfType<Project>();
         }*/
    
}
