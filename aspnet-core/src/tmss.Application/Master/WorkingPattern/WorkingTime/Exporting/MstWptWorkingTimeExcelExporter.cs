using System.Collections.Generic;
using tmss.Dto;
using tmss.DataExporting.Excel.NPOI;
using tmss.Storage;
using tmss.Master.WorkingPattern.Dto;

namespace tmss.Master.WorkingPattern.Exporting
{
	public class MstWptWorkingTimeExcelExporter : NpoiExcelExporterBase, IMstWptWorkingTimeExcelExporter
	{
		public MstWptWorkingTimeExcelExporter(ITempFileCacheManager tempFileCacheManager) : base(tempFileCacheManager) { }
		public FileDto ExportToFile(List<MstWptWorkingTimeDto> workingtime)
		{
			return CreateExcelPackage(
				"MasterWorkingPatternWorkingTime.xlsx",
				excelPackage =>
				{
				var sheet = excelPackage.CreateSheet("WorkingTime");
				AddHeader(
							sheet,
							("ShiftNo"),
								("ShopId"),
								("WorkingType"),
								("StartTime"),
								("EndTime"),
								("Description"),
								("PatternHId"),
								("SeasonType"),
								("DayOfWeek"),
								("WeekWorkingDay"),
								("IsActive")
							   );
			AddObjects(
				 sheet, 1, workingtime,
						_ => _.ShiftNo,
						_ => _.ShopId,
						_ => _.WorkingType,
						_ => _.StartTime,
						_ => _.EndTime,
						_ => _.Description,
						_ => _.PatternHId,
						_ => _.SeasonType,
						_ => _.DayOfWeek,
						_ => _.WeekWorkingDays,
						_ => _.IsActive

						);

			for (var i = 0; i < 8; i++)
			{
				sheet.AutoSizeColumn(i);
			}
		});

        }
}
}
