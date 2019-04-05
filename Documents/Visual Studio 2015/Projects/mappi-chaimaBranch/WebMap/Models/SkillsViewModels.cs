using DomainMap.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebMap.Models
{
    public class SkillsViewModels
    {
        public int SkillsId { get; set; }
        public String name { get; set; }
        public int Difficulity { get; set; }

        public int userId{ get; set; }



    }
}