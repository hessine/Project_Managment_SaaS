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
    public class ServiceMandate :ServicePattern<Mandate> ,IServiceMandate
    {
        private static IDatabaseFactory dbFac = new DatabaseFactory();
        private static IUnitOfWork wow = new UnitOfWork(dbFac);
        public ServiceMandate() : base(wow)
        {
        }
      
        public IEnumerable<Resource> getListRessource(int ProjectId)
        {
            

            throw new NotImplementedException();
        }
    }
}
