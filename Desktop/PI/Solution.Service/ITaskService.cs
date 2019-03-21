using Service.Pattern;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
    public interface ITaskService:IService<Domain.Entities.Task>
    {
        IEnumerable<Domain.Entities.Task> Searchfilm(string ch);
    }
}
