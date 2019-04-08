using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityV2.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityV2.Data
{
    class ApplicationUserStore: UserStore<User>
    {
        public ApplicationUserStore(MyContext context) : base(context)
        {
        }


    }
}
