using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tmss.Master
{
    [Table("UnPackingPart")]
    public class UnPackingPart : FullAuditedEntity<long>, IEntity<long>
    {
        public const int MaxUnpackingNoLength = 50;

        public const int MaxModuleNoLength = 50;

        public const int MaxRenbanLength = 50;

        public const int MaxSuppilerNoLength = 50;

        public const int MaxShiftNoLength = 20;

        public const int MaxUnpackingTypeLength = 20;

        public const int MaxUnpackingStatusLength = 20;

        [StringLength(MaxUnpackingNoLength)]
        public virtual string UnpackingNo { get; set; }

        [StringLength(MaxModuleNoLength)]
        public virtual string ModuleNo { get; set; }

        [StringLength(MaxRenbanLength)]
        public virtual string Renban { get; set; }

        [StringLength(MaxSuppilerNoLength)]
        public virtual string SuppilerNo { get; set; }

        [StringLength(MaxShiftNoLength)]
        public virtual string ShiftNo { get; set; }

        public virtual DateTime WorkingDate { get; set; }

        public virtual DateTime PlanUnpackingDate { get; set; }
        public virtual DateTime ActUnpackingDate { get; set; }
        public virtual DateTime ActUnpackingDateFinish { get; set; }

        [StringLength(MaxUnpackingTypeLength)]
        public virtual string UnpackingType { get; set; }

        [StringLength(MaxUnpackingStatusLength)]
        public virtual string UnpackingStatus { get; set; }

    }
}
