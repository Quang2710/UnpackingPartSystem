using System;
using System.Collections.Generic;
using System.Text;

namespace tmss.Master.Unpacking.Dto
{
    public class UnpackingExportInput
    {
        public string ModuleNo { get; set; }

        public string DevaningNo { get; set; }

        public string Renban { get; set; }
        public string Supplier { get; set; }


        public DateTime? PlanUnpackingDate { get; set; }
        public DateTime? ActUnpackingDate { get; set; }
        public DateTime? ActUnpackingDateFinish { get; set; }

        public string ModuleStatus { get; set; }
    }
}
