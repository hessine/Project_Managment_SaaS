using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainMap.Entities
{
    public enum TypeMessage {claim,satisfaction,TechnicalProblems }
  public  class Message
    {
        [Key]
        public int MessageId { get; set; }
        public String Titre { get; set; }
        public String Description { get; set; }
        public TypeMessage typeMessage { get; set; }
        public virtual User userM { get; set; }





    }
}
