using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tmss.Master
{
    [Table("Robing")]
    public class Robings : FullAuditedEntity<long>, IEntity<long>
    {
        [StringLength(50)]
        public virtual string PartNo { get; set; }

        [StringLength(50)]
        public virtual string PartName { get; set; }


        [StringLength(50)]
        public virtual string ModuleNo { get; set; }

        [StringLength(50)]
        public virtual string Supplier { get; set; }

        [StringLength(50)]
        public virtual string Renban { get; set; }

        [StringLength(50)]
        public virtual string Type { get; set; }

        [StringLength(500)]
        public virtual string Description { get; set; }

    }
}
