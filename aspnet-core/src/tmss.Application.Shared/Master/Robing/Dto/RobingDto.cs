using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace tmss.Master.Robing.Dto
{
    public class RobingDto : Entity<long?>
    {       
        public virtual string PartNo { get; set; }

       public virtual string PartName { get; set; }

        public virtual string ModuleNo { get; set; }

        public virtual string Supplier { get; set; }

        public virtual string Renban { get; set; }

        public virtual string Type { get; set; }

        public virtual string Description { get; set; }

    }
}
