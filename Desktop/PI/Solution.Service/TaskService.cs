using Service.Pattern;
using Solution.Data.Infrastructure;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
  
    
        public class TaskService : Service<Domain.Entities.Task>, ITaskService


        {
    
        static IDataBaseFactory Factory = new DataBaseFactory();//l'usine de fabrication du context
            static IUnitOfWork utk = new UnitOfWork(Factory);//unité de travail a besoin du factory pour communiquer avec la base
            public TaskService() : base(utk)
            {


            }

        public IEnumerable<Domain.Entities.Task> Searchfilm(string ch)
         {
             IEnumerable<Domain.Entities.Task> taskDomain = GetMany();
             if (!String.IsNullOrEmpty(ch))
             {
                taskDomain = GetMany(x => x.Name.Contains(ch));
             }
             return taskDomain;
         }

       
    }
}
