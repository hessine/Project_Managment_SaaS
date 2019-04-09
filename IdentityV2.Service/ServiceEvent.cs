using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityV2.Domain.Entities;
using IdentityV2.ServicePattern;

using IdentityV2.Data.Infrastructure;

namespace IdentityV2.Service

{
    public class ServiceEvent : Service<Events>, IServiceEvent
    {


        static IDataBaseFactory Factory = new DataBaseFactory();
        static IUnitOfWork utk = new UnitOfWork(Factory);
        public ServiceEvent() : base(utk)
        {
        }

    }
}
