using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityV2.Domain.Entities
{
    public class Company
    {
        public int CompanyId { get; set; }

        public string Name { get; set; }

        public string LogoUrl { get; set; }

        //prop de navigation 

        public virtual ICollection<User> Users { get; set; }
    }
}
