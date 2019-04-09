using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityV2.Data.Infrastructure;
using IdentityV2.Domain.Entities;
using IdentityV2.ServicePattern;
using System.Collections;

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

        public IEnumerable<User> GetRoleMember()
        {

            //     return GetMany(t => t.Role == 1).OfType<User>();
            //user.Roles.

            throw new NotImplementedException();



        }

        public int GetTotalUsers()
        {

            IEnumerable t = GetMany().OfType<User>();
            int count = 0;
            foreach (var element in t)
            {
                count++;
            }

            return count;
        }

        public IEnumerable<User> GetUserByRole()
        {
            throw new NotImplementedException();
        //    string currentUserId = User.Identity.GetUserId();

        }
    }
}
