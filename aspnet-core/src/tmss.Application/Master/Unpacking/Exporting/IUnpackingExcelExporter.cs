using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using tmss.Dto;
using tmss.Master.Unpacking.Dto;

namespace tmss.Master.Unpacking.Exporting
{
    public interface IUnpackingExcelExporter : IApplicationService
    {
        FileDto ExportToFile(List<UnpackingDto> unpacking);

        FileDto ExportToFilePartList(List<PartListDto> partlist);
    }
}
