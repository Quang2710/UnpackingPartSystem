using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using tmss.Dto;
using tmss.Master.Module.Dto;

namespace tmss.Master.Module.Exporting
{
    public interface IModuleExcelExporter: IApplicationService
    {
        FileDto ExportToFile(List<ModuleDto> module);
    }
}
