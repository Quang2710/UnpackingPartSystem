﻿using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tmss.Master.WorkingPattern
{
  
		[Table("MstWptWorkingTime")]		
		public class MstWptWorkingTime : FullAuditedEntity<long>, IEntity<long>
		{

			public const int MaxDescriptionLength = 250;

			public const int MaxSeasonTypeLength = 10;

			public const int MaxDayOfWeekLength = 100;

			public const int MaxIsActiveLength = 1;

			public virtual int ShiftNo { get; set; }

			public virtual int ShopId { get; set; }

			public virtual int WorkingType { get; set; }

			public virtual TimeSpan StartTime { get; set; }

			public virtual TimeSpan EndTime { get; set; }

			[StringLength(MaxDescriptionLength)]
			public virtual string Description { get; set; }

			public virtual int PatternHId { get; set; }

			[StringLength(MaxSeasonTypeLength)]
			public virtual string SeasonType { get; set; }

			[StringLength(MaxDayOfWeekLength)]
			public virtual string DayOfWeek { get; set; }

			public virtual int WeekWorkingDays { get; set; }

			[StringLength(MaxIsActiveLength)]
			public virtual string IsActive { get; set; }
		}
	}
