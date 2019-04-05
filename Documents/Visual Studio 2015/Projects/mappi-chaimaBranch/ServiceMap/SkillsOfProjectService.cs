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
    public class SkillsOfProjectService :ServicePattern<Skillsofproject> , ISkillsOfProject
    {
        private static IDatabaseFactory dbFac = new DatabaseFactory();
        private static IUnitOfWork wow = new UnitOfWork(dbFac);
        public SkillsOfProjectService() : base(wow)
        {
        }
        public IEnumerable<Skillsofproject> listskills(int id)
        {
            return GetMany(t => t.numproj == id);
        }

        public Boolean testadd(int idp, int ids)
        {
            //Skillsofproject sp = new Skillsofproject();

            var sp = Get(t => t.numskill == ids);
            if (sp != null)
            {
                if (sp.numproj == idp)
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
