using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using tmss.Dto;
using tmss.Master.Robing.Dto;
using tmss.Master.Unpacking.Dto;

namespace tmss.Master.Robing.Exporting
{
    public interface IRobingExcelExporter : IApplicationService
    
    {
        FileDto ExportToFile(List<RobingDto> robing);

    }
}
