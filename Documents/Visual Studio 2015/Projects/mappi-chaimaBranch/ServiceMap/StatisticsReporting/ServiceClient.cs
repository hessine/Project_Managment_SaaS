using DomainMap.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DataMap.Infrastructure;

namespace ServiceMap.StatisticsReporting
{
   public class ServiceClient : ServicePattern<Client>, IServiceClient
    {

        private static IDatabaseFactory dbFac = new DatabaseFactory();
        private static IUnitOfWork wow = new UnitOfWork(dbFac);

        public ServiceClient() : base(wow)
        {
        }

        //Service permet de retourner le nombre des clients
        public int NombresOfClients()
        {
            return GetAll().Count();
        }
    }







}

