using IdentityV2.ServicePattern;
using IdentityV2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityV2.Service
{
    public interface IServiceProject : IService<Project>
    {
        IEnumerable<Project> GetProjectWaiting();
        IEnumerable<Project> GetProjectavailable();
        int GetTotalProjects();
    }
}
