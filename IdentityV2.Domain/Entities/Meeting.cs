using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityV2.Domain.Entities
{
    public class Meeting
    {


        [Key]
        [DHXJson(Alias = "id")]
        public int Id { get; set; }

        [DHXJson(Alias = "text")]
        public string Description { get; set; }

        [DHXJson(Alias = "start_date")]
        public DateTime StartDate { get; set; }

        [DHXJson(Alias = "end_date")]
        public DateTime EndDate { get; set; }


    }
}
