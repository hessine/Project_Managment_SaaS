using IdentityV2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityV2.Domain.Entities
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
       // public Adress Address { get; set; }
        public String Picture { get; set; }
        public string Description { get; set; }
        public int Etat { get; set; }

        public int ClientFK { get; set; }
        public int CatIdFK { get; set; }
        public int TotalNbrRessources { get; set; }
        public int TotalNbrRessourcesLevio { get; set; }
      //  public virtual Category Category { get; set; }
       // public virtual ICollection<Resource> ListResource { get; set; }
        public virtual User client { get; set; }

        //[InverseProperty("ProjectSkills")]
        //[ForeignKey("numproject")]
        //public virtual ICollection<Skillsofproject> ProjectSkills { get; set; }
        public virtual ICollection<TaskPM> tasks { get; set; }

      //  public virtual ICollection<Document> Documents { get; set; }



    }
}
