using System;
using System.Collections.Generic;
using System.Text;
using tmss.DataExporting.Excel.NPOI;
using tmss.Dto;
using tmss.Master.Unpacking.Dto;
using tmss.Storage;

namespace tmss.Master.Unpacking.Exporting
{
    public class UnpackingExcelExporter : NpoiExcelExporterBase, IUnpackingExcelExporter
    {
        public UnpackingExcelExporter(ITempFileCacheManager tempFileCacheManager) : base(tempFileCacheManager) { }

        public FileDto ExportToFile(List<UnpackingDto> unpacking)
        {
            return CreateExcelPackage(
                "Unpacking.xlsx",
                excelPackage =>
                {
                    var sheet = excelPackage.CreateSheet("Unpacking");
                    AddHeader(
                                sheet,
                                ("UnpackingNo"),
                                    ("ModuleNo"),
                                    ("Renban"),
                                    ("SuppilerNo"),
                                    ("ShiftNo"),
                                    ("WorkingDate"),
                                    ("PlanUnpackingDate"),
                                    ("ActUnpackingDate"),
                                    ("ActUnpackingDateFinish"),
                                    ("UnpackingType"),
                                    ("UnpackingStatus")
                                   );
                    AddObjects(
                         sheet, 1, unpacking,
                                _ => _.UnpackingNo,
                                _ => _.ModuleNo,
                                _ => _.Renban,
                                _ => _.SuppilerNo,
                                _ => _.ShiftNo,
                                _ => _.WorkingDate,
                                _ => _.PlanUnpackingDate,
                                _ => _.ActUnpackingDate,
                                _ => _.ActUnpackingDateFinish,
                                _ => _.UnpackingType,
                                _ => _.UnpackingStatus

                                );

                    for (var i = 0; i < 8; i++)
                    {
                        sheet.AutoSizeColumn(i);
                    }
                });
        }
    }
}
