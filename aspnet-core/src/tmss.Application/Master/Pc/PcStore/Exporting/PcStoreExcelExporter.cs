using System;
using System.Collections.Generic;
using System.Text;
using tmss.DataExporting.Excel.NPOI;
using tmss.Dto;
using tmss.Master.Pc;
using tmss.Master.Pc.PcStore.Exporting;
using tmss.Storage;

namespace tmss.Master.Exporting
{
    public class PcStoreExcelExporter : NpoiExcelExporterBase, IPcStoreExcelExporter
    {
        public PcStoreExcelExporter(ITempFileCacheManager tempFileCacheManager) : base(tempFileCacheManager) { }
        public FileDto ExportToFile(List<PcStoreDto> pchome)
        {
            return CreateExcelPackage(
                "PcStore.xlsx",
                excelPackage =>
                {
                    var sheet = excelPackage.CreateSheet("PcStore");
                    AddHeader(
                                sheet,
                                    "PartNo",
                                    "PartName"
                                   );
                    AddObjects(
                         sheet, 1, pchome,
                                _ => _.PartNo,
                                _ => _.PartName

                                );

                    for (var i = 0; i < 8; i++)
                    {
                        sheet.AutoSizeColumn(i);
                    }
                });
        }
    }
}
