using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainMap.Entities
{

    public class Applicant:User
    {
        public String Country { get; set; }
        public int Age { get; set; }
     
        public String Picture { get; set; }
    }
}
