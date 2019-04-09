using IdentityV2.Domain.Entities;
using IdentityV2.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityV2.Data.Infrastructure;

namespace IdentityV2.Service
{
    public class ServiceProject : Service<Project>, IServiceProject
    {
        static IDataBaseFactory Factory = new DataBaseFactory();
        static IUnitOfWork utk = new UnitOfWork(Factory);
        public ServiceProject() : base(utk)
        {
        }
        public IEnumerable<Project> GetProjectavailable()
        {
            return GetMany(t => t.Etat == 1).OfType<Project>();
        }

        public IEnumerable<Project> GetProjectWaiting()
        {
            return GetMany(t => t.Etat == 0).OfType<Project>();
        }
        public int GetTotalProjects()
        {


            /* IEnumerable t = GetMany().OfType<Project>();
             int count = 0;
             foreach (var element in t)
             {
                 count++;
             }

             return count;*/




            return GetMany().Count();

        }
    }
}
