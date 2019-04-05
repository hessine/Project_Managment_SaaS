using DataMap.Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMap
{
    public class CategoryService : ServicePattern<DomainMap.Entities.Category>, ICategoryService
    {
        private static IDatabaseFactory dbFac = new DatabaseFactory();
        private static IUnitOfWork wow = new UnitOfWork(dbFac);
        public CategoryService() : base(wow)
        {

        }
    }
}
