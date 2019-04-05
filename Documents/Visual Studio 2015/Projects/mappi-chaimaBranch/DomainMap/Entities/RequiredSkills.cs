using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainMap.Entities
{
  public  class RequiredSkills
    {
        [Key]
        public int RequiredSkillsId { get; set; }
        [Required(ErrorMessage = "required field")]
        public string nomSkill { get; set; }
        [Required(ErrorMessage = "required field")]
        public int experience { get; set; }
        [Required(ErrorMessage = "required field")]
        public String education { get; set; }
        [Required(ErrorMessage = "required field")]
        public String profil { get; set; }

        public virtual Request request { get; set; }
        public int requestId { get; set; }


    }
}
