using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace tmss.Master.Unpacking.Dto
{
    public class UnpackingDto : Entity<long?>
    {
        public  string UnpackingNo { get; set; }

        public  string ModuleNo { get; set; }

        public  string Renban { get; set; }
        public  string SuppilerNo { get; set; }
        public  string ShiftNo { get; set; }

        public  DateTime? WorkingDate { get; set; }

        public  DateTime? PlanUnpackingDate { get; set; }
        public  DateTime? ActUnpackingDate { get; set; }
        public  DateTime? ActUnpackingDateFinish { get; set; }

        public  string UnpackingType { get; set; }

        public  string UnpackingStatus { get; set; }
    }
    public class PartInModuleDto : Entity<long?>
    {
        public string ModuleNo { get; set; }
        public string PartNo { get; set; }

        public string PartName { get; set; }

        public string Renban { get; set; }

        public string Supplier { get; set; }

        public string Status { get; set; }        
    }
}
