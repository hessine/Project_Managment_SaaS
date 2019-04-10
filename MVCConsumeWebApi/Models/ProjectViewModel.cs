using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MVCConsumeWebApi.Models
{
    public class ProjectViewModel
    {

        public int ProjectId { get; set; }
        public String Name { get; set; }
       
        public DateTime DateBegin { get; set; }
      
        public DateTime DateEnd { get; set; }
       
       
        public int TotalNbrRessources { get; set; }
     
        public string Description { get; set; }
       
      

       
       
      
    }
}