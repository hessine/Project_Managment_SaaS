using DataMap.Infrastructure;
using DomainMap.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMap.StatisticsReporting
{
    public class ServiceResource : ServicePattern<Resource>,IServiceResource
    {


        private static IDatabaseFactory dbFac = new DatabaseFactory();
        private static IUnitOfWork wow = new UnitOfWork(dbFac);

        public ServiceResource() : base(wow)
        {
        }

        //Service permet de retourner le nombre de resources
        public int NombreOfResources()
        {
            return GetAll().Count();
        }



        //Service permet de retourner resource par nom
        public IEnumerable<Resource> ResourceByName(string name)
        {
            IEnumerable<Resource> listrs = new List<Resource>();
            listrs = GetAll().ToList();

            IEnumerable<Resource> result = (from r in listrs
                                            where r.UserName == name
                                            select (r));
            return result;

        }

                                 


        // Service permet de retourner nombres de resources par availibility
        public int ResourceByAvailibility(TypeAvailability av)
        {

            IEnumerable<Resource> listrs = new List<Resource>();

            listrs = GetAll().ToList();

            int result = (from r in listrs
                          where r.Availability == av
                          select r).Count();
            return result;
        }

        //Service permet de retourner les resources par seniority

        //public int ResourceBySeniority(Seniority sen)
        //{
        //    IEnumerable<Resource> listrs = new List<Resource>();

        //    listrs = GetAll().ToList();

        //    int result = (from r in listrs
        //                  where r.Seniority == sen select r).Count();
        //    return result;

        //}


        // Service permet de retourner les resources freelancers
        public int ResourceFreelancer()
        {
            IEnumerable<Resource> listrs = new List<Resource>();

            listrs = GetAll().ToList();

            int result = (from r in listrs
                          where r.Contrat == TypeContrat.Freelancer
                          select r).Count();

            return result;

        }


        // Service permet de retourner nombres de resources indayoff
        public int ResourceInDayOff()
        {

            IEnumerable<Resource> listr = new List<Resource>();
            IEnumerable<DayOff> listDayoff = new List<DayOff>();

            ServicePattern<DayOff> serday = new ServicePattern<DayOff>(wow);
            
            listDayoff = serday.GetAll().ToList();
            listr = GetAll().ToList();
            DateTime date = DateTime.Now;
            int resultjoin = (from d in listDayoff
                             join r in listr
                             on d.ResourceId equals r.Id
                             where (d.DateBegin <= date && d.DateEnd >= date) 
                             select (r)).Distinct().Count() ;
           
            return resultjoin;




           


           
            

               

        }
    }
}
