using DomainMap.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMap.Models
{
    public enum RequestState { untreated, denied, reported, accepted }
    public class RequestViewModel
    {

        [Key]
        public int RequestId { get; set; }
     
        public String LastName { get; set; }
        public String FirstName { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public DateTime DateDeposit { get; set; }
        public string subject { get; set; }
        public float coast { get; set; }
        public int nbrResource { get; set; }
        public int ClientId { get; set; }

        public ClientViewModel client { get; set; }
        // public virtual ICollection<RequiredSkills> listRequiredSkills { get; set; }
        public DateTime ReportedDate { get; set; }
        [EnumDataType(typeof(RequestState))]
        public RequestState state { get; set; }
       //public List<RequiredSkillsViewModel> listSkills { get; set; }

        //attribut Required Skills
        public string nomSkill { get; set; }
        public int experience { get; set; }
        public String education { get; set; }
        public String profil { get; set; }


        public string Email { get; set; }

    }

}