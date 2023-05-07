using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace tmss.Master.Module.Dto
{
    public class CreateOrEditModuleDto:Entity<long?>
    {
        public  string ModuleNo { get; set; }

        public  string DevaningNo { get; set; }        

        public  string ModuleStatus { get; set; }
    }
}
