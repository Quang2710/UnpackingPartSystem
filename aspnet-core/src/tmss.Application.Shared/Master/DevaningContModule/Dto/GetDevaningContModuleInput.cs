using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace tmss.Master.DevaningContModule.Dto
{
    public class GetDevaningContModuleInput: PagedAndSortedResultRequestDto
    {
        public virtual string DevaningNo { get; set; }

        public virtual string ContainerNo { get; set; }

        public virtual string Renban { get; set; }
        public virtual string SuppilerNo { get; set; }
        public virtual string ShiftNo { get; set; }

        public virtual string DevaningType { get; set; }

        public virtual string DevaningStatus { get; set; }
    }
}
