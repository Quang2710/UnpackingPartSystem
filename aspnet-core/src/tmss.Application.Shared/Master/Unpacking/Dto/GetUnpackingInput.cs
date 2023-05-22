using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using tmss.Dto;

namespace tmss.Master.Unpacking.Dto
{
    public class GetUnpackingInput: PagedAndSortedResultRequestDto
    {
        public  string ModuleNo { get; set; }

        public  string DevaningNo { get; set; }

        public  string Renban { get; set; }
        public  string Supplier { get; set; }        
                
        public  string ModuleStatus { get; set; }
        
    }
}
