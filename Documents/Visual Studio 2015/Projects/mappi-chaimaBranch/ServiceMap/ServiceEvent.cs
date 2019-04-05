using DomainMap;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMap.Infrastructure;

namespace ServiceMap
{
    public class ServiceEvent : ServicePattern<Events>, IServiceEvent
    {
        private static IDatabaseFactory dbFac = new DatabaseFactory();
        private static IUnitOfWork wow = new UnitOfWork(dbFac);
        public ServiceEvent() : base(wow)
        {
        }
    }
}
