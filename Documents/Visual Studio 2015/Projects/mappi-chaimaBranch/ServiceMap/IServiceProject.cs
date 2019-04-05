using DomainMap.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMap
{
   public interface IServiceProject : IServicePattern<Project>
    {
        IEnumerable<Project> GetProjectWaiting();
        IEnumerable<Project> GetProjectavailable();
    }
}
