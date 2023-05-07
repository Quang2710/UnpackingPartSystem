using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using tmss.Dto;

namespace tmss.Master.Unpacking.Dto
{
    public class GetUnpackingInput: PagedAndSortedResultRequestDto
    {
        public  string UnpackingNo { get; set; }

        public  string ModuleNo { get; set; }

        public  string Renban { get; set; }
        public  string SuppilerNo { get; set; }
        public  string ShiftNo { get; set; }
                
        public  string UnpackingType { get; set; }

        public  string UnpackingStatus { get; set; }
    }
}
