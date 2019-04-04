using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityV2.Data.Infrastructure;
using IdentityV2.Domain.Entities;
using IdentityV2.ServicePattern;

namespace IdentityV2.Service
{
    public class UserService: Service<User>,IUserService
    {
        static IDataBaseFactory DBF = new DataBaseFactory();
        static IUnitOfWork UOW = new UnitOfWork(DBF);

        public UserService() : base(UOW)
        {
        }

        public UserService(IUnitOfWork UOW) : base(UserService.UOW)
        {

        }
    }
}
