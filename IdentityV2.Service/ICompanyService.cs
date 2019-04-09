using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityV2.Domain.Entities;
using IdentityV2.ServicePattern;

namespace IdentityV2.Service
{
    public interface ICompanyService: IService<Company>
    {
    }
}
