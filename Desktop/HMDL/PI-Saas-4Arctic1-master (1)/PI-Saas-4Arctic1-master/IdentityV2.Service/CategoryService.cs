using IdentityV2.Data.Infrastructure;
using IdentityV2.Domain.Entities;
using IdentityV2.ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityV2.Service
{
    public class CategoryService : Service<Category>,ICategoryService
    {
        static IDataBaseFactory Factory = new DataBaseFactory();
        static IUnitOfWork utk = new UnitOfWork(Factory);
        public CategoryService() : base(utk)
        {

        }
    }
}
