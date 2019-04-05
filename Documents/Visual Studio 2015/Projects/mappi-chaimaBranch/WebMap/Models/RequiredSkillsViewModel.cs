using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMap.Models
{
   // public enum RequestState { untreated, denied, reported, accepted }
    public class RequiredSkillsViewModel
    {
        public int RequiredSkillsId { get; set; }
        public string nomSkill { get; set; }
        public int experience { get; set; }
        public String education { get; set; }
        public int requestId { get; set; }
        public String profil { get; set; }






    }
}