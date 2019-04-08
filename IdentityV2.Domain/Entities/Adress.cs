using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityV2.Domain.Entities
{
    public class Adress
    {
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public int Longitude { get; set; }
        public int Latitude { get; set; }
        public string Country { get; set; }
    }
}
