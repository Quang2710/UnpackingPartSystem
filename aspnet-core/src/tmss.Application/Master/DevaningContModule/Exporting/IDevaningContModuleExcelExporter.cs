using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using tmss.Dto;
using tmss.Master.DevaningContModule.Dto;

namespace tmss.Master.DevaningContModule.Exporting
{
    public interface IDevaningContModuleExcelExporter : IApplicationService
    {
        FileDto ExportToFile(List<DevaningContModuleDto> devaningcontmodule);
    }
}
