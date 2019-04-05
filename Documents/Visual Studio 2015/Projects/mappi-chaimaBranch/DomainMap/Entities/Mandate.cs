using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DomainMap.Entities
{
    public enum TypeMandate {Inter_Mandate,Mandate }
   public class Mandate
    {
        [Key,Column(Order=0)]
        [Required]
        public int ProjectId { get; set; }
        [Key, Column(Order = 1)]
        public int userId { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "MMMM dd, yyyy")]
        public DateTime DateBegin { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "MMMM dd, yyyy")]
        public DateTime DateEnd { get; set; }
        //DataType[DataType.Currency]
        [Required]
        [DataType(DataType.Currency)]
        public float Cost { get; set; }
        [Required]
        public int Duree { get; set; }
        public  TypeMandate mandat{ get; set; }
        public virtual Resource resource { get; set; }
        public virtual Project projet { get; set; }


    }
}
