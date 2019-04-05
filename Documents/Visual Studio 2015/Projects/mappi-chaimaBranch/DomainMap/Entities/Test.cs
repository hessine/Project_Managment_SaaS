using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DomainMap.Entities

{
   public class Test
    {
        [Key]
        public int TestId { get; set; }
        public String Nom { get; set; }
        public String Difficulty { get; set; }
        public DateTime DateTest { get; set; }
        public float Mark { get; set; }
        public virtual File file { get; set; }
    }
}
