using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityV2.ServicePattern;
using IdentityV2.Domain.Entities;


namespace IdentityV2.Service
{
    public interface IServiceEvent : IService<Events>
    {
    }
}
