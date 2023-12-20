using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tmss.Dto;
using tmss.Master.Exporting;

namespace tmss.Master.Pc
{
    public class PcHomeAppService : tmssAppServiceBase , IPcHomeAppService
    {
        private readonly IRepository<PcHome, long> _pchome;
        private readonly IPcHomeExcelExporter _calendarListExcelExporter;


        public PcHomeAppService(IRepository<PcHome, long> pchome,
                                 IPcHomeExcelExporter calendarListExcelExporter)

        {
            _pchome = pchome;
            _calendarListExcelExporter = calendarListExcelExporter;
        }

        public async Task<List<PcHomeDto>> GetAll(PcHomeInputDto input)
        {
            var query = _pchome.GetAll().AsNoTracking()
                .Where(e => string.IsNullOrWhiteSpace(input.PartNo) || e.PartNo.Contains(input.PartNo))
                .Select(PcStore => new PcHomeDto
                {
                    Id = PcStore.Id,
                    PartNo = PcStore.PartNo,
                    PartName = PcStore.PartName,
                });

            return await query.ToListAsync();
        }
        public async Task<FileDto> GetPcHomeToExcel(PcHomeInputDto input)
        {
            var query = _pchome.GetAll().AsNoTracking()
                 .Where(e => string.IsNullOrWhiteSpace(input.PartNo) || e.PartNo.Contains(input.PartNo))
                 .Select(PcStore => new PcHomeDto
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
