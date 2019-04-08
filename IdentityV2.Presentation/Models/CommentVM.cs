using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

using IdentityV2.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace IdentityV2.Presentation.Models
  
{
    public class CommentVM
    {
        public int CommentId { get; set; }
        public string Text { get; set; }

        [Display(Name = " Name Of task")]

        public int  TaskId { get; set; } // comment can be nulled
        [ForeignKey("TaskId")] //0..1
        public virtual TaskPM TaskPM { get; set; }

      //  [Display(Name = " Name Of task")]

        public string taskname { get; set; }
       // [Display(Name = "Status of Task")]

        public string taskStatus { get; set; }

    }
}