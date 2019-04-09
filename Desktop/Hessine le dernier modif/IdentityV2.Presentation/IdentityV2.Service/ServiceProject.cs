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
    public class ServiceProject : Service<Project>, IServiceProject
    {
        private static IDataBaseFactory dbFac = new DataBaseFactory();
        private static IUnitOfWork wow = new UnitOfWork(dbFac);
        public ServiceProject() : base(wow)
        {
        }

        public IEnumerable<Project> GetProjectavailable()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetProjectWaiting()
        {
            throw new NotImplementedException();
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
