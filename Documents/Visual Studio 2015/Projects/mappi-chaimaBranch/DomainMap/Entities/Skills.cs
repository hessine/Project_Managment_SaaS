using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainMap.Entities
{
    public class Skills
    {
        [Key]
        public int SkillsId { get; set; }
        public String name { get; set; }
        public int Difficulity { get; set; }
        public String speciality { get; set; }
        //[InverseProperty("ResourceSkills")]
        //public virtual ICollection<Resource> ResourceSkills { get; set; }
        //[InverseProperty("ProjectSkills")]
        //public virtual ICollection<Project> ProjectSkills { get; set; }
        public virtual ICollection<resourceSkills> listResourceSkills { get; set; }

    }
}
