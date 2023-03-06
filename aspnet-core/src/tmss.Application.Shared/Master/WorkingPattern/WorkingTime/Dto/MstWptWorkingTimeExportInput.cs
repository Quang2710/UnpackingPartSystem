using Abp.Application.Services.Dto;
using System;
using System.ComponentModel.DataAnnotations;
namespace vovina.Master.WorkingPattern.Dto
{

	public class MstWptWorkingTimeExportInput
	{

		public virtual int ShiftNo { get; set; }

		public virtual int ShopId { get; set; }

		public virtual int WorkingType { get; set; }

		public virtual TimeSpan? StartTime { get; set; }

		public virtual TimeSpan? EndTime { get; set; }

		public virtual string Description { get; set; }

		public virtual int PatternHId { get; set; }

		public virtual string SeasonType { get; set; }

		public virtual string DayOfWeek { get; set; }

		public virtual int WeekWorkingDays { get; set; }

		public virtual string IsActive { get; set; }

	}

}


