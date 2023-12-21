using System;
using System.Collections.Generic;
using System.Text;
using tmss.DataExporting.Excel.NPOI;
using tmss.Dto;
using tmss.Master.Robing.Dto;
using tmss.Master.Unpacking.Dto;
using tmss.Master.Unpacking.Exporting;
using tmss.Storage;

namespace tmss.Master.Robing.Exporting
{
    public class RobingExcelExporter : NpoiExcelExporterBase, IRobingExcelExporter          
    {
        public RobingExcelExporter(ITempFileCacheManager tempFileCacheManager) : base(tempFileCacheManager) { }
        public FileDto ExportToFile(List<RobingDto> unpacking)
        {
            return CreateExcelPackage(
                "Robing.xlsx",
                excelPackage =>
                {
                    var sheet = excelPackage.CreateSheet("Robing");
                    AddHeader(
                                sheet,
                                    ("PartNo"),
                                    ("PartName"),
                                    ("ModuleNo"),
                                    ("Supplier"),
                                    ("Renban"),
                                    ("Type"),
                                    ("Description")
                                   );
                    AddObjects(
                         sheet, 1, unpacking,
                                _ => _.PartNo,
                                _ => _.PartName,
                                _ => _.ModuleNo,
                                _ => _.Supplier,
                                _ => _.Renban,
                                _ => _.Type,
                                _ => _.Description

                                );

                    for (var i = 0; i < 8; i++)
                    {
                        sheet.AutoSizeColumn(i);
                    }
                });
        }
    }
}
