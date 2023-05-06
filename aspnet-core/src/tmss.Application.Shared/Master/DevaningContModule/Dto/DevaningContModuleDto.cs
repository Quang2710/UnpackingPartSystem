using Abp.Application.Services.Dto;
using System;
using System.ComponentModel.DataAnnotations;
using tmss.Master.WorkingPattern;

namespace tmss.Master.DevaningContModule.Dto
{
    public class DevaningContModuleDto : EntityDto<long?>
    {
        public virtual string DevaningNo { get; set; }

        public virtual string ContainerNo { get; set; }

        public virtual string Renban { get; set; }
        public virtual string SuppilerNo { get; set; }
        public virtual string ShiftNo { get; set; }

        public virtual DateTime WorkingDate { get; set; }

        public virtual DateTime PlanDevaningDate { get; set; }
        public virtual DateTime ActDevaningDate { get; set; }
        public virtual DateTime ActDevaningDateFinish { get; set; }

        public virtual string DevaningType { get; set; }

        public virtual string DevaningStatus { get; set; }

    }

    public class CreateOrEditDevaningContModuleDto : EntityDto<long?>
    {

        public virtual string DevaningNo { get; set; }

        public virtual string ContainerNo { get; set; }

        public virtual string Renban { get; set; }
        public virtual string SuppilerNo { get; set; }
        public virtual string ShiftNo { get; set; }

        public virtual DateTime WorkingDate { get; set; }

        public virtual DateTime PlanDevaningDate { get; set; }
        public virtual DateTime ActDevaningDate { get; set; }
        public virtual DateTime ActDevaningDateFinish { get; set; }

        public virtual string DevaningType { get; set; }

        public virtual string DevaningStatus { get; set; }
    }

    public class GetDevaningContModuleModuleInput : PagedAndSortedResultRequestDto
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
