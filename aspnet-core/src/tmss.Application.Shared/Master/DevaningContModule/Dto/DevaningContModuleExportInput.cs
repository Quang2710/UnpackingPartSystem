using System;
using System.Collections.Generic;
using System.Text;

namespace tmss.Master.DevaningContModule.Dto
{
    public class DevaningContModuleExportInput
    {
        public  string DevaningNo { get; set; }

        public  string ContainerNo { get; set; }

        public  string Renban { get; set; }
        public  string SuppilerNo { get; set; }
        public  string ShiftNo { get; set; }

        public  DateTime WorkingDate { get; set; }

        public  DateTime PlanDevaningDate { get; set; }
        public  DateTime ActDevaningDate { get; set; }
        public  DateTime ActDevaningDateFinish { get; set; }

        public  string DevaningType { get; set; }

        public  string DevaningStatus { get; set; }
    }
}
