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
   public class ServiceHistoricalMandate:ServicePattern<HistoricalMandate>,IServiceHistoricalMandate
    {
        private static IDatabaseFactory dbFac = new DatabaseFactory();
        private static IUnitOfWork wow = new UnitOfWork(dbFac);
        public ServiceHistoricalMandate() : base(wow)
        {
        }
    }
}
