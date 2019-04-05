using System;
using ServicePattern;
using DomainMap.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMap.StatisticsReporting
{
    interface IServiceMandat : IServicePattern<Mandate>
    {

        int nbMandats();
        Dictionary<int, int> getMostTerm(DateTime? dateFrom, DateTime? dateTo);

    }
}
