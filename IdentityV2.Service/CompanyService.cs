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
    public class CompanyService: Service<Company>, ICompanyService
    {
        static IDataBaseFactory Factory = new DataBaseFactory();//l'usine de fabrication du context
        static IUnitOfWork utk = new UnitOfWork(Factory);//unité de travail a besoin du factory pour communiquer avec la base
        public CompanyService():base(utk)
        {

        }

    }
}
