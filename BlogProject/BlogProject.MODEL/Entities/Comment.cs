using BlogProject.CORE.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.MODEL.Entities
{
   public class Comment : CoreEntity
    {
        public string CommentText { get; set; }

        public Guid UserID { get; set; }
        public Guid PostID { get; set; }


        //Navigation property


    }
}
