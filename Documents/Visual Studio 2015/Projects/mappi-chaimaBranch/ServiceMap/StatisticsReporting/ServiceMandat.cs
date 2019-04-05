using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMap.Infrastructure;
using DomainMap.Entities;
using ServicePattern;

namespace ServiceMap.StatisticsReporting
{
   public  class ServiceMandat : ServicePattern<Mandate> , IServiceMandat
    {

        private static IDatabaseFactory dbFac = new DatabaseFactory();
        private static IUnitOfWork wow = new UnitOfWork(dbFac);

        public ServiceMandat() : base(wow)
        {
        }

        public Dictionary<int, int> getMostTerm(DateTime? dateFrom, DateTime? dateTo)
        {
            Resource r = new Resource();
            long count = new long();

            if (dateFrom == null)
                dateFrom = new DateTime();
            if (dateTo == null)
                dateTo = new DateTime();

            IEnumerable<Resource> listr = new List<Resource>();
            IEnumerable<Mandate> listMandats = new List<Mandate>();

            ServicePattern<Resource> ser = new ServicePattern<Resource>(wow);

            listMandats = GetAll().ToList();
            listr = ser.GetAll().ToList();

            Dictionary<int, int> mostMandats = new Dictionary<int, int>();

            mostMandats = (from man in listMandats
                           join res in listr
                           on man.userId equals res.Id
                           where (dateFrom <= man.DateBegin && man.DateBegin >= dateTo) || (dateFrom <= man.DateEnd && man.DateEnd >= dateTo)
                           group man by man.userId into g
                           orderby g.Count() descending
                           select (g)).ToDictionary(g => g.Key , g=> g.Count());

            // dateFrom <= man.DateBegin && dateTo >= man.DateBegin || dateFrom >= man.DateBegin && dateTo <= man.DateEnd || dateFrom <= man.DateEnd && dateTo >= man.DateEnd

            return mostMandats;

                       }

        public int nbMandats()
        {
            return GetAll().Count();
        }
    }
}
