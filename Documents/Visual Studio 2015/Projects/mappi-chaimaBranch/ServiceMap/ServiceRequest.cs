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
    public class ServiceRequest:ServicePattern<Request>,IRequestService
    {
        private static IDatabaseFactory dbfactory = new DatabaseFactory();
        private static IUnitOfWork UOW = new UnitOfWork(dbfactory);
        public ServiceRequest():base(UOW)
        { }
    }
}
