using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainMap.Entities
{
public    class File
    {
        [Key]
        public int FileId { get; set; }
        public DateTime DateBegin { get; set; }
        public virtual ICollection<Documents> ListDocument { get; set; }
        public virtual  ICollection<Test> ListTest { get; set; }
    }
}
