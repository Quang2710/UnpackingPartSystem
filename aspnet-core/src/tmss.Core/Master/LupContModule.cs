using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tmss.Master
{
    [Table("LupContModule")]
    public class LupContModule : FullAuditedEntity<long>, IEntity<long>    {
  

        [StringLength(50)]
        public virtual string ModuleNo { get; set; }

        [StringLength(50)]
        public virtual string DevaningNo { get; set; }

        [StringLength(50)]
        public virtual string Supplier { get; set; }


        [StringLength(50)]
        public virtual string Renban { get; set; }

        public virtual DateTime? PlanUnpackingDate { get; set; }

        public virtual DateTime? ActUnpackingDate { get; set; }

        public virtual DateTime? ActUnpackingDateFinish { get; set; }

        [StringLength(50)]
        public virtual string ModuleStatus { get; set; }

    }
}
