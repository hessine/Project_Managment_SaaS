using DomainMap.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebMap.Models
   
{
    //public enum TypeContart { Freelancer, Employee }
    //public enum TypeAvailability { Available, NotAvailable, AvailableSoon }
    public class ResourceViewModel:UserViewModel
    {

        public int userId { get; set; }
        public String PictureResource { get; set; }
        public HttpPostedFileBase Image { get; set; }

        public int ProjectId { get; set; }
        public String Cv { get; set; }
        public TypeContrat Contrat { get; set; }
        public string BuissnesSector { get; set; }
        public String Seniority { get; set; }
        public TypeAvailability Availability { get; set; }
        public String EmployementLetter { get; set; }
        public virtual ICollection<Project> ListeProject { get; set; }
        public virtual ICollection<Message> ListMessage { get; set; }

        public virtual ICollection<Skills> ListSkills { get; set; }
        public virtual ICollection<DayOff> ListDayOff { get; set; }
        [ForeignKey("userId")]
        public virtual ICollection<Mandate> ListMandate { get; set; }

    }
}