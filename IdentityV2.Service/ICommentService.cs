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
    public interface ICommentService : IService<Comment>
    {
        IEnumerable<Comment> GetCommentByTask(int idTask);
        IEnumerable<Comment> getCommentPerTask(int id);

    }
}
