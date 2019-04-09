using IdentityV2.Domain.Entities;
using IdentityV2.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityV2.Service
{
    public interface IDocumentService : IService<Documents>
    {
        IEnumerable<Documents> SearchDocumentByName(string searchString);
    }
}