using System;
using System.Collections.Generic;
using System.Text;
using tmss.DataExporting.Excel.NPOI;
using tmss.Dto;
using tmss.Master.DevaningContModule.Dto;
using tmss.Storage;

namespace tmss.Master.DevaningContModule.Exporting
{
    public class DevaningContModuleExcelExporter : NpoiExcelExporterBase, IDevaningContModuleExcelExporter
    {
        public DevaningContModuleExcelExporter(ITempFileCacheManager tempFileCacheManager) : base(tempFileCacheManager) { }
        public FileDto ExportToFile(List<DevaningContModuleDto> devaningcontmodule)
        {
            return CreateExcelPackage(
                "DevaningContModule.xlsx",
                excelPackage =>
                {
                    var sheet = excelPackage.CreateSheet("DevaningContModule");
                    AddHeader(
                                sheet,
                                ("DevaningNo"),
                                    ("ContainerNo"),
                                    ("Renban"),
                                    ("SuppilerNo"),
                                    ("ShiftNo"),
                                    ("WorkingDate"),
                                    ("PlanDevaningDate"),
                                    ("ActDevaningDate"),
                                    ("ActDevaningDateFinish"),
                                    ("DevaningType"),
                                    ("DevaningStatus")
                                   );
                    AddObjects(
                         sheet, 1, devaningcontmodule,
                                _ => _.DevaningNo,
                                _ => _.ContainerNo,
                                _ => _.Renban,
                                _ => _.SuppilerNo,
                                _ => _.ShiftNo,
                                _ => _.WorkingDate,
                                _ => _.PlanDevaningDate,
                                _ => _.ActDevaningDate,
                                _ => _.ActDevaningDateFinish,
                                _ => _.DevaningType,
                                _ => _.DevaningStatus

                                );

                    for (var i = 0; i < 8; i++)
                    {
                        sheet.AutoSizeColumn(i);
                    }
                });
        }
    }
}
