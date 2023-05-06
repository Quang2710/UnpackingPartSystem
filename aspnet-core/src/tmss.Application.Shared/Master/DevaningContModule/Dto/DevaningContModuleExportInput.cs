using System;
using System.Collections.Generic;
using System.Text;

namespace tmss.Master.DevaningContModule.Dto
{
    public class DevaningContModuleExportInput
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
}
