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
                                ("ModuleNo"),
                                    ("DevaningNo"),
                                    ("Renban"),
                                    ("Supplier"),
                                    ("ActUnpackingDate"),
                                    ("ActUnpackingDateFinish"),
                                    ("PlanUnpackingDate"),
                                    ("ModuleStatus")                                    
                                   );
                    AddObjects(
                         sheet, 1, unpacking,
                                _ => _.ModuleNo,
                                _ => _.DevaningNo,
                                _ => _.Renban,
                                _ => _.Supplier,
                                _ => _.ActUnpackingDate,
                                _ => _.ActUnpackingDateFinish,
                                _ => _.PlanUnpackingDate,
                                _ => _.ModuleStatus
                                
                                );

                    for (var i = 0; i < 8; i++)
                    {
                        sheet.AutoSizeColumn(i);
                    }
                });
        }
        public FileDto ExportToFilePartList(List<PartListDto> partlist)
        {
            return CreateExcelPackage(
                "PartList.xlsx",
                excelPackage =>
                {
                    var sheet = excelPackage.CreateSheet("PartList");
                    AddHeader(
                                sheet,
                                    ("PartNo"),
                                    ("ModuleNo"),
                                    ("PartName"),
                                    ("Renban"),
                                    ("Supplier"),
                                    ("Status")                                   
                                   );
                    AddObjects(
                         sheet, 1, partlist,
                                _ => _.PartNo,
                                _ => _.ModuleNo,
                                _ => _.PartName,
                                _ => _.Renban,
                                _ => _.Supplier,
                                _ => _.Status                            
                                );

                    for (var i = 0; i < 8; i++)
                    {
                        sheet.AutoSizeColumn(i);
                    }
                });
        }
    }
}
