using DataMap.Infrastructure;
using DomainMap.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMap
{
    public class ServiceClient : ServicePattern<Client>, IServiceClient
    {
        private static IDatabaseFactory dbFac = new DatabaseFactory();
        private static IUnitOfWork wow = new UnitOfWork(dbFac);
        public ServiceClient() : base(wow)
        {
        }
    }
}




