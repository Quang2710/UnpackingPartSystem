using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using vovina.Master.WorkingPattern.Dto;
using tmss.Dto;

namespace vovina.Master.WorkingPattern.Exporting
{

	public interface IMstWptWorkingTimeExcelExporter : IApplicationService
	{

		FileDto ExportToFile(List<MstWptWorkingTimeDto> mstwptworkingtime);

	}

}


