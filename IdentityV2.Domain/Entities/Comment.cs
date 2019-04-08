using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace IdentityV2.Domain.Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Text { get; set; }
        public int TaskId { get; set; } // comment can be nulled
        [ForeignKey("TaskId")] //0..1
        public virtual TaskPM TaskPM { get; set; }
    }

}
