using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMTool_SaaS.Models
{
    public class Project
    {
        [Key]
        public int ProId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int? CatgId { get; set; }
        [ForeignKey("CatgId")]
     
        public virtual ICollection<Task> Tasks { get; set; }

    }
}