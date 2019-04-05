using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace DomainMap.Entities
{
  public  class Skillsofproject
    {
        [Key]
        public int skillsofprojectId { get; set; }
        public int numproj { get; set; }
        public int numskill { get; set; }
    }
}
