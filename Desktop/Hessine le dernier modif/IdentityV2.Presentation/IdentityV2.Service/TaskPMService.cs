using IdentityV2.Data.Infrastructure;
using IdentityV2.Domain.Entities;
using IdentityV2.ServicePattern;
using System;
using System.Collections;
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

        public IEnumerable<TaskPM> USERbyRole()
        {
            throw new NotImplementedException();
        }
        //H

        IEnumerable<TaskPM> ITaskPMService.GetTaskPMDone()
        {
            return GetMany(t => t.Status == "Done").OfType<TaskPM>();
        }

        IEnumerable<TaskPM> ITaskPMService.GetTaskPMDoing()
        {
            return GetMany(t => t.Status == "Doing").OfType<TaskPM>();
        }

        public IEnumerable<TaskPM> GetTaskPMToDo()
        {
            return GetMany(t => t.Status == "todo").OfType<TaskPM>();
        }
        //





        public int GetTotalTasks()
        {

            IEnumerable t = GetMany().OfType<TaskPM>();
         //   var listTask = new List<int>
                int count = 0;
            foreach (var element in t)
            {
                count++;
                //Console.WriteLine($"Element #{count}: {element}");
            }

            return count;


        }


        //Service permet de retourner resource par nom

      
        public int NbTaskByStatusToDo()
        {
            IEnumerable<TaskPM> listtask = new List<TaskPM>();
            listtask = GetMany().ToList();

            int result = (from r in listtask
                          where r.Status =="todo"
                          select r).Count();
            return result;
        }



        //Doing
        public int NbTaskByStatusDoing()
        {

            IEnumerable<TaskPM> listtask = new List<TaskPM>();
            listtask = GetMany().ToList();

            int result1 = (from r in listtask
                          where r.Status =="Doing"
                          select r).Count();
            return result1;
        }

        //Done
        public int NbTaskByStatusDone()
        {
            IEnumerable<TaskPM> listtask = new List<TaskPM>();
            listtask = GetMany().ToList();

            int result2 = (from r in listtask
                          where r.Status =="Done"
                          select r).Count();
            return result2;
        }

        public int FinishTaskEarly()
        {
            IEnumerable<TaskPM> AlllistTask = new List<TaskPM>();

            AlllistTask = GetMany().ToList();
            //DateTime date = DateTime.Now;
            int resultjoin = (from r in AlllistTask
                               where r.EndDate < r.DeadLine
                               select r).Count();
            return resultjoin;
        }
   
        public IEnumerable<TaskPM> ReturnFinishTaskEarly()
        {
            IEnumerable<TaskPM> AlllistTask = new List<TaskPM>();

            AlllistTask = GetMany().ToList();
            //DateTime date = DateTime.Now;
            IEnumerable<TaskPM> resultjoin2 = (from r in AlllistTask
                              where r.EndDate < r.DeadLine
                              select (r));

            return resultjoin2;

        }

        public int nbrTaskInProject()
        {
            throw new NotImplementedException();

            /*
                        IEnumerable<TaskPM> listr = new List<TaskPM>();
                        IEnumerable<Project> listPro = new List<Project>();

                        Service<Project> serPro = new Service<Project>(wow);

                        listPro = serPro.GetMany().ToList();
                        listr = GetMany().ToList();
                        DateTime date = DateTime.Now;
                        int resultjoin3 = (from d in listPro
                                           join r in listr
                                          on d.ProjectId equals r.ProjectId
                                        //  where (d.DateBegin <= date && d.DateEnd >= date)
                                          select (r)).Distinct().Count();

                        return resultjoin3;*/


        }
    }

   



}
