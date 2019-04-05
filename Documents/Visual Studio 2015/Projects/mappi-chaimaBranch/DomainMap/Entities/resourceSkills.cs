using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainMap.Entities
{
   public class resourceSkills
    
    { 
        
        [Key, Column(Order = 0)]
        public int userId { get; set; }
        [Key, Column(Order = 1)]
        public int SkillsId { get; set; }
    }
}
