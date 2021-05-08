using BlogProject.CORE.Entity.Abstract;
using BlogProject.CORE.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.CORE.Concrete
{
    public class CoreEntity : IEntity<Guid>
    {
        // 0C8BF8C5-3EBD-4BC8-B71E-194404247637

        public Guid ID { get; set; }
        public Status Status { get; set; }

        public DateTime? CreatedDate { get; set; }
        public string CreatedComputerName { get; set; }
        public string CreatedIP { get; set; }

        public DateTime? ModifiedCreatedDate { get; set; }
        public string ModifiedCreatedComputerName { get; set; }
        public string ModifiedCreatedIP { get; set; }


    }
}
