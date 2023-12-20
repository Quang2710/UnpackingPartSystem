using Abp.Application.Services.Dto;
using Abp.Dapper.Repositories;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tmss.Dto;
using tmss.Master.Exporting;
using tmss.Master.Pc;
using tmss.Master.Pc.PcStore.Exporting;

namespace tmss.Master
{
    public class PcStoreAppService : tmssAppServiceBase, IPcStoreAppService
    {
        private readonly IRepository<PcStore, long> _pcstore;
        private readonly IPcStoreExcelExporter _calendarListExcelExporter;


        public PcStoreAppService(IRepository<PcStore, long> pcstore,
                                IPcStoreExcelExporter calendarListExcelExporter)
        {
            _pcstore = pcstore;
            _calendarListExcelExporter = calendarListExcelExporter;
        }

        public async Task<List<PcStoreDto>> GetAll(PcStoreInputDto input)
        {
            var query = _pcstore.GetAll().AsNoTracking()
                 .Where(e => string.IsNullOrWhiteSpace(input.PartNo) || e.PartNo.Contains(input.PartNo))
                .Select(PcStore => new PcStoreDto
                {
                    Id = PcStore.Id,
                    PartNo = PcStore.PartNo,
                    PartName = PcStore.PartName,
                });

            return await query.ToListAsync();
        }
        public async Task<FileDto> GetPcStoreToExcel(PcStoreInputDto input)
        {
            var query = _pcstore.GetAll().AsNoTracking()
                 .Where(e => string.IsNullOrWhiteSpace(input.PartNo) || e.PartNo.Contains(input.PartNo))
                 .Select(PcStore => new PcStoreDto
                 {
                     Id = PcStore.Id,
                     PartNo = PcStore.PartNo,
                     PartName = PcStore.PartName,
                 });
            var exportToExcel = await query.ToListAsync();
            return _calendarListExcelExporter.ExportToFile(exportToExcel);
        }

    }


}
