using System;
using System.Collections.Generic;
using System.Text;
using tmss.DataExporting.Excel.NPOI;
using tmss.Dto;
using tmss.Master.DevaningContModule.Dto;
using tmss.Master.Pc;
using tmss.Storage;

namespace tmss.Master.Exporting
{
    public class PcHomeExcelExporter : NpoiExcelExporterBase, IPcHomeExcelExporter
    {
        public PcHomeExcelExporter(ITempFileCacheManager tempFileCacheManager) : base(tempFileCacheManager) { }
        public FileDto ExportToFile(List<PcHomeDto> pchome)
        {
            return CreateExcelPackage(
                "PcHome.xlsx",
                excelPackage =>
                {
                    var sheet = excelPackage.CreateSheet("DevaningContModule");
                    AddHeader(
                                sheet,
                                    ("PartNo"),
                                    ("PartName")                                    
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
