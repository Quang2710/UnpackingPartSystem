using Abp.Application.Services;
using System.Collections.Generic;
using tmss.Dto;
using tmss.Master.WorkingPattern.Dto;

namespace tmss.Master.WorkingPattern.Exporting
{

	public interface IMstWptWorkingTimeExcelExporter : IApplicationService
	{

		FileDto ExportToFile(List<MstWptWorkingTimeDto> mstwptworkingtime);

	}

}


