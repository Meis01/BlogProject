using BlogProject.CORE.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.MODEL.Entities
{
   public class Category : CoreEntity
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }

        //Navigation Property
    }
}
