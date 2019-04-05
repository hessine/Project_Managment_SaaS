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
    public class ServiceSkills : ServicePattern<Skills>, IServiceSkills
    {
        private static IDatabaseFactory dbFac = new DatabaseFactory();
        private static IUnitOfWork wow = new UnitOfWork(dbFac);
        public ServiceSkills() : base(wow)
        {
        }
    }
}
