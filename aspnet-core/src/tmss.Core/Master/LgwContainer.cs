﻿using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tmss.Master
{
    [Table("LgwContainer")]
    public class LgwContainer : FullAuditedEntity<long>, IEntity<long>
    {


        public const int MaxContainerNoLength = 50;

        public const int MaxRenbanLength = 50;

        public const int MaxSuppilerNoLength = 50;

        [StringLength(MaxContainerNoLength)]
        public virtual string ContainerNo { get; set; }

        [StringLength(MaxRenbanLength)]
        public virtual int Renban { get; set; }

        [StringLength(MaxSuppilerNoLength)]
        public virtual int SuppilerNo { get; set; }

    }
}
