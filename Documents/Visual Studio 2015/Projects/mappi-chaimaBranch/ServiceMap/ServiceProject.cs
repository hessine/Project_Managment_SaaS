using DomainMap.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMap.Infrastructure;

namespace ServiceMap
{
    public class ServiceProject : ServicePattern<Project>, IServiceProject
    {
        private static IDatabaseFactory dbFac = new DatabaseFactory();
        private static IUnitOfWork wow = new UnitOfWork(dbFac);
        public ServiceProject() : base(wow)
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
    }
}
