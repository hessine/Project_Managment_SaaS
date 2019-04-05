using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainMap.Entities
{
    public enum TypeContrat {Freelancer,Employee }
    public enum TypeAvailability {Available,NotAvailable,AvailableSoon }
   public  class Resource:User
    {
       // public int ResourceId { get; set; }
       // public String FirstName { get; set; }
       // public String LastName { get; set; }
        public String PictureResource { get; set; }
    
        public String Cv { get; set; }
        public TypeContrat Contrat { get; set; }
        public string BuissnesSector { get; set; }
      
        public String Seniority { get; set; }
    
        public TypeAvailability Availability { get; set; }
        public String EmployementLetter { get; set; }
        //wael hetha champs zetou ena nesthakou
       // public Boolean EtatM { get; set; }
      //   public virtual ICollection<Project> ListeProject { get; set; }
        public virtual ICollection<Message> ListMessage{ get; set; }
        //[InverseProperty("ResourceSkills")]
        //public virtual ICollection<Skills> ResourceSkills { get; set; }
        public bool archive { get; set; }
        [ForeignKey("userId")]
        public virtual ICollection<resourceSkills> ListResourceSkills { get; set; }
        public virtual ICollection<DayOff> ListDayOff { get; set; }
        [ForeignKey("userId")]
        public virtual ICollection<Mandate> ListMandate { get; set; }
       



    }
}
