using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainMap.Entities
{
    public enum RequestState { untreated, denied, reported, accepted }
    public class Request
    {
        [Key]
        public int RequestId { get; set; }
        [Required(ErrorMessage = "required field")]
        public DateTime DateBegin { get; set; }
        [Required(ErrorMessage = "required field")]
        public DateTime DateEnd { get; set; }
        public DateTime DateDeposit { get; set; }
        [Required(ErrorMessage = "required field")]
        public string subject { get; set; }
        [Required(ErrorMessage = "required field")]
        public float coast { get; set; }
        [Required(ErrorMessage = "required field")]
        public int nbrResource { get; set; }

        public int ClientId { get; set; }

        public Client client { get; set; }

        public virtual ICollection<RequiredSkills> listRequiredSkills { get; set; }
        [Required(ErrorMessage = "required field")]
        public DateTime ReportedDate { get; set; }

        [EnumDataType(typeof(RequestState))]
        public RequestState state { get; set; }


    }
}
