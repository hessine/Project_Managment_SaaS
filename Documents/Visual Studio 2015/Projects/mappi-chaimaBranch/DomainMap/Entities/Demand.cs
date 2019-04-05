using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DomainMap.Entities

{
    public enum DemandState
    {Processing,Waiting,Denied
       
    }
  public  class Demands
    {
        [Key]
        public int DemandId { get; set; }
        public DateTime date { get; set; }
        public DemandState State { get; set; }
        
        
    }
}
