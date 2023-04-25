using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tmss.Master
{
    [Table("LupContModule")]
    public class LupContModule : FullAuditedEntity<long>, IEntity<long>
    {
        public const int MaxModuleNoLength = 50;

        public const int MaxDevaningNoLength = 50;

        public const int MaxModuleStatusLength = 20;

        [StringLength(MaxModuleNoLength)]
        public virtual string ModuleNo { get; set; }

        [StringLength(MaxDevaningNoLength)]
        public virtual string DevaningNo { get; set; }

        [StringLength(MaxModuleStatusLength)]
        public virtual string ModuleStatus { get; set; }

    }
}
