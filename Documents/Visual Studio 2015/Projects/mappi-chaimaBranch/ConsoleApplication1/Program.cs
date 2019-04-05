using DomainMap.Entities;
using ServiceMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
   public class Program
    {
      public  static void Main(string[] args)
        {
         
            List<Resource> listR = new List<Resource>();
            List<Skills> listS = new List<Skills>();
            List<Skills> listSR = new List<Skills>();
            List<Mandate> listM = new List<Mandate>();
            IServiceMandate Sm = new ServiceMandate();
            IServiceProject sp = new ServiceProject();
            IServiceSkills sk = new ServiceSkills();
            IServiceResource rs = new ServiceResource();
            //Mandate m = Sm.GetAll().Where(a => a.ProjectId == 3).Where(t => t.userId == 1).First();
            //Console.WriteLine(m.Duree);
            //Console.ReadKey();
           // TimeSpan ts = 23/11/2018 -02/11/2018;
           
            List<Mandate> listH = new List<Mandate>();
            //Console.WriteLine(DateTime.Today);
            //DateTime d1 = new DateTime(14 / 11 / 2018);
            //DateTime d2 = new DateTime(16 / 11 / 2018);
            //TimeSpan d3 = d2 - d1;
            //int d = (int)d3.TotalDays;
            DateTime dtToday = new System.DateTime(2012, 6, 2, 0, 0, 0);
            DateTime dtMonthBefore = new System.DateTime(2012, 5, 2, 0, 0, 0);
            TimeSpan diffResult = dtToday.Subtract(dtMonthBefore);
            Console.WriteLine(diffResult.TotalDays);

            // int d3 = (int)(d2-d1).TotalDays;
            //Console.WriteLine(d3);
            Console.ReadKey();
            //listH = Sm.GetAll().Where().ToList();
            //foreach(var item in listH)
            //{
            //    Console.WriteLine(item.Duree);
            //}


            //  Project p = sp.Get(a => a.ProjectId == 6);
            //Console.WriteLine(p.ProjectId);


            //        listR = rs.GetAll().ToList();
            //      //  listS = sk.GetAll().ToList();
            //        listS = p.ProjectSkills.ToList();
            //        listM=Sm.GetAll().ToList();
            //        //foreach (var i in listR)
            //        //{
            //        //    Console.WriteLine(i.Email);

            //        //}
            //        ////  Console.ReadKey();

            //        //foreach (var r in listS)
            //        //{

            //        //    Console.WriteLine(r.name);
            //        //    // Console.WriteLine(r);

            //        //}



            //        //foreach (var t in listS)
            //        //{
            //        //    Console.WriteLine(t.SkillsId);
            //        //   // Console.WriteLine(t);

            //        //}
            //     //   Console.ReadKey();


            //        foreach (var item in listS)
            //        {

            //            foreach (var item2 in listR)
            //            {



            //                foreach (var item3 in item2.ResourceSkills)
            //                {
            //                    foreach (var item4 in listM)
            //                    {
            //                        //Console.WriteLine(item3.SkillsId);
            //                        //Console.ReadKey();
            //                        if ((item.SkillsId == item3.SkillsId)&&(item4.ProjectId!=p.ProjectId))
            //                        {

            //                            //Console.WriteLine(item2.FirstName);
            //                            //Console.ReadKey();
            //                            Mandate m = new Mandate();

            //                            m.ProjectId = p.ProjectId;
            //                            m.Cost = 50;
            //                            m.DateBegin = DateTime.Today;
            //                            m.DateEnd = DateTime.Today;
            //                            m.Duree = "25";
            //                            m.userId = 1;
            //                            Sm.Add(m);
            //                            Sm.Commit();

            //                            Console.WriteLine("ok");
            //                            Console.ReadKey();

            //                        }
            //                    }
            //                }
            //            }

            //        }






        }
    }
    }
