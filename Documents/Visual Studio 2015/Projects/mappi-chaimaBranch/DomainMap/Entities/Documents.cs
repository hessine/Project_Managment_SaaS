using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainMap.Entities
{
    public enum TypeDocument
    {
        Letter, Baccalaureate, Diploma

    }
 public   class Documents
    {
        [Key]
        public int DocumentsId { get; set; }
        public TypeDocument Type { get; set; }
        public String Titre { get; set; }
        public virtual File file { get; set; }

    }
}
