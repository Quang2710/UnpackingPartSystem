using Abp.Application.Services.Dto;
using System;


namespace tmss.Master.DevaningContModule.Dto
{
    public class DevaningContModuleDto : EntityDto<long?>
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

    public class DevaningScreenDto : EntityDto<long?>
    {
        public string DevaningNoCurrent { get; set; }

        public string ContainerNoCurrent { get; set; }

        public string RenbanCurrent { get; set; }

        public string ContainerNoNext { get; set; }

        public string RenbanNext { get; set; }


        public string DevaningNoNext { get; set; }

        public DateTime TimeLine { get; set; }

        public int? TimeLineHour { get; set; }

        public int? TimeLineMinute { get; set; }

        public int? TimeLineSecond { get; set; }

    }

    public class CoutPlanDvn : EntityDto<long?>
    {

        public int Id { get; set; }
        public string COUNT_DEVANING { get; set; }

        public string Status { get; set; }
    }


}
