using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityV2.Data.Infrastructure;
using IdentityV2.Domain.Entities;

namespace IdentityV2.Service
{
    public class ServiceUser 
    {
        static IDataBaseFactory dbf = new DataBaseFactory();

        static IUnitOfWork utwk = new UnitOfWork(dbf);

        public ServiceUser(IUnitOfWork utwk)
        {
        }



        public bool checkUserByRole(User us)
        {
            return false;
        }

        public void addRoleToUser(User u)
        {
        }

    }
}
