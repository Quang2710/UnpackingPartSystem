using System;
using System.Collections.Generic;
using System.Text;
using tmss.DataExporting.Excel.NPOI;
using tmss.Dto;
using tmss.Master.Module.Dto;
using tmss.Storage;

namespace tmss.Master.Module.Exporting
{
    public class ModuleExcelExporter : NpoiExcelExporterBase, IModuleExcelExporter
    {
        public ModuleExcelExporter(ITempFileCacheManager tempFileCacheManager) : base(tempFileCacheManager) { }
        

        public FileDto ExportToFile(List<ModuleDto> module)
        {
            return CreateExcelPackage(
                "Module.xlsx",
                excelPackage =>
                {
                    var sheet = excelPackage.CreateSheet("Module");
                    AddHeader(
                                sheet,
                                ("ModuleNo"),
                                    ("DevaningNo"),
                                    ("SuppilerNo"),
                                    ("ModuleStatus")

                                   );
                    AddObjects(
                         sheet, 1, module,
                                _ => _.ModuleNo,
                                _ => _.DevaningNo,
                                _ => _.SuppilerNo,
                                _ => _.ModuleStatus
                                


                                );

                    for (var i = 0; i < 8; i++)
                    {
                        sheet.AutoSizeColumn(i);
                    }
                });
        }
    }
}
