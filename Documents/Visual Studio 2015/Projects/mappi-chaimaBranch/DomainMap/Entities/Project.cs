using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainMap.Entities
{
   public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public String Name { get; set; }
        [DisplayFormat(DataFormatString = "MMMM dd, yyyy")]
        public DateTime DateBegin { get; set; }
        [DisplayFormat(DataFormatString = "MMMM dd, yyyy")]
        public DateTime DateEnd { get; set; }
        public Adress Address { get; set; }
        public String Picture { get; set; }
        public string Description { get; set; }
        public int Etat { get; set; }

        
        public int CatIdFK { get; set; }
        public int TotalNbrRessources { get; set; }
        
        public virtual Category Category { get; set; }
        public virtual ICollection<Resource> ListResource { get; set; }
       
        
        //[InverseProperty("ProjectSkills")]
        //[ForeignKey("numproject")]
        //public virtual ICollection<Skillsofproject> ProjectSkills { get; set; }
        public virtual ICollection<Request> listRequest { get; set; }
        




    }
}
