using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using tmss.Dto;
using tmss.Master.Pc;

namespace tmss.Master.Pc.PcStore.Exporting
{
    public interface IPcStoreExcelExporter : IApplicationService
    {
        FileDto ExportToFile(List<PcStoreDto> pcStore);
    }
}
