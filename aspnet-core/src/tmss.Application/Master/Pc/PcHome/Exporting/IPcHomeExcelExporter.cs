using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using tmss.Dto;
using tmss.Master.Pc;

namespace tmss.Master.Exporting
{
    public interface IPcHomeExcelExporter : IApplicationService
    {
        FileDto ExportToFile(List<PcHomeDto> pchome);
    }
}
