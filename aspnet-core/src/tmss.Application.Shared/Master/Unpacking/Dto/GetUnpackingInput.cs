using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using tmss.Dto;

namespace tmss.Master.Unpacking.Dto
{
    public class GetUnpackingInput: PagedAndSortedResultRequestDto
    {
        public virtual string UnpackingNo { get; set; }

        public virtual string ModuleNo { get; set; }

        public virtual string Renban { get; set; }
        public virtual string SuppilerNo { get; set; }
        public virtual string ShiftNo { get; set; }
                
        public virtual string UnpackingType { get; set; }

        public virtual string UnpackingStatus { get; set; }
    }
}
