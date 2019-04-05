using DomainMap.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMap.Models
{
    public class StatisticsViewModels
    {

        public UserViewModel UserViewModel { get; set; }
        public ResourceViewModel ResourceViewMdel { get; set; }
        public ProjectViewModel ProjectViewModel { get; set; }

        public int nbProjects { get; set; }
        public int nbClients { get; set; }
        public int nbResources { get; set; }

        public IEnumerable<Project> projects { get; set; }

        public StatisticsViewModels(IEnumerable<Project> pirates)
        {
            projects = pirates;
        }

        public StatisticsViewModels()
        {
           
        }


    }
}