using IdentityV2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdentityV2.Presentation.Models
{
    public class ProjectViewModel
    {

        public int ProjectId { get; set; }
        public String Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateBegin { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateEnd { get; set; }
       public Adress Address { get; set; }
        public String Picture { get; set; }
        public int TotalNbrRessources { get; set; }
       public int TotalNbrRessourcesLevio { get; set; }
       public Adress Adress { get; set; }
        public string Description { get; set; }
        public int Etat { get; set; }
        public int CatIdFK { get; set; }
      //  public int ClientFK { get; set; }
        /// <upload image>


        [DisplayName("Upload file")]
        public string ImagePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
      
    }
}