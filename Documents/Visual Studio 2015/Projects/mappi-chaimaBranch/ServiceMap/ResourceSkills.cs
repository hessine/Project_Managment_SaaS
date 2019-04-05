using DataMap.Infrastructure;
using DomainMap.Entities;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceMap
{
   public class ResourceSkills: ServicePattern<resourceSkills>,IResourceSkills
    {
        private static IDatabaseFactory databaseFactory = new DatabaseFactory();
        private static IUnitOfWork unit = new UnitOfWork(databaseFactory);
        public ResourceSkills() : base(unit)
        {

        }
        public Boolean testadd(int idp, int ids)
        {
            //Skillsofproject sp = new Skillsofproject();

            var sp = Get(t => t.SkillsId == ids);
            if (sp != null)
            {
                if (sp.userId == idp)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
    }
}
