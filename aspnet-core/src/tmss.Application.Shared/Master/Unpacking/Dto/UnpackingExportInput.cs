using System;
using System.Collections.Generic;
using System.Text;

namespace tmss.Master.Unpacking.Dto
{
    public class UnpackingExportInput
    {
        public virtual string UnpackingNo { get; set; }

        public virtual string ModuleNo { get; set; }

        public virtual string Renban { get; set; }
        public virtual string SuppilerNo { get; set; }
        public virtual string ShiftNo { get; set; }

        public virtual DateTime WorkingDate { get; set; }

        public virtual DateTime PlanUnpackingDate { get; set; }
        public virtual DateTime ActUnpackingDate { get; set; }
        public virtual DateTime ActUnpackingDateFinish { get; set; }

        public virtual string UnpackingType { get; set; }

        public virtual string UnpackingStatus { get; set; }
    }
}
