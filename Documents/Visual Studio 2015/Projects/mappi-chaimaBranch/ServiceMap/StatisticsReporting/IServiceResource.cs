using DomainMap.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMap.StatisticsReporting
{
    interface IServiceResource : IServicePattern<Resource>
    {
        int NombreOfResources();
      //  int ResourceBySeniority(Seniority sen);
        int ResourceFreelancer();
        int ResourceByAvailibility(TypeAvailability av);
        int ResourceInDayOff();
        IEnumerable<Resource> ResourceByName(String name);

        
    }
}
