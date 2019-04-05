using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DomainMap.Entities
{
    public enum State {SeekDays,Maternety,Holidays }
  public  class DayOff
    {
        public int DayOffId { get; set; }
        public DateTime DateBegin { get; set; }
        public DateTime DateEnd { get; set; }
        public State state { get; set; }
        public int ResourceId { get; set; }
        public virtual  Resource resource { get; set; }


    }
}
