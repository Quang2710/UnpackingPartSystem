using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace tmss.Master.Module.Dto
{
    public class GetModuleInput: PagedAndSortedResultRequestDto
    {
        public virtual string ModuleNo { get; set; }

        public virtual string DevaningNo { get; set; }

        public virtual string SuppilerNo { get; set; }

        public virtual string ModuleStatus { get; set; }
    }
}
