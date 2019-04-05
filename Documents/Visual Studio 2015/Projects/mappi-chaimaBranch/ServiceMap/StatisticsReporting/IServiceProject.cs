using DomainMap.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMap.StatisticsReporting
{
    interface IServiceProject : IServicePattern<Project>
    {
        int NombreOfProjects();

        IEnumerable<Project> mapTaux();
    }
}
