using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tmss.Master
{
    [Table("PcStore")]
    public class PcStore : FullAuditedEntity<long>, IEntity<long>
    {       

        [StringLength(50)]
        public virtual string PartNo { get; set; }

        [StringLength(50)]
        public virtual string PartName { get; set; }
        
    }

}
