using BlogProject.CORE.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.MODEL.Entities
{
   public class Post : CoreEntity
    {
        public string Title { get; set; }
        public string PostDetail { get; set; }
        public string Tags { get; set; }
        public string Imagepath { get; set; }
        public int ViewCount { get; set; }

        public Guid CategoryID { get; set; }
        public Guid UserID { get; set; }

        //Navigation property

    }
}
