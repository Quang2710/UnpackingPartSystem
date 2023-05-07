using Abp.Application.Services.Dto;
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
using tmss.Master.Module.Dto;
using tmss.Master.Module.Exporting;


namespace tmss.Master.Module
{
    public class ModuleAppService : tmssAppServiceBase, IModuleAppService
    {
        private readonly IRepository<LupContModule, long> _module;
        private readonly IRepository<DvnContList, long> _suppilerno;
        private readonly IModuleExcelExporter _calendarListExcelExporter;

        public ModuleAppService(IRepository<LupContModule, long> module, IRepository<DvnContList, long> suppilerno,
            IModuleExcelExporter calendarListExcelExporter)
        {
            _module = module;
            _suppilerno = suppilerno;
            _calendarListExcelExporter = calendarListExcelExporter;
        }

        public async Task CreateOrEdit(CreateOrEditModuleDto input)
        {
            if (input.Id == null)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }

        }

        //Create
        protected virtual async Task Create(CreateOrEditModuleDto input)
        {
            var mainObj = ObjectMapper.Map<LupContModule>(input);
            await _module.InsertAsync(mainObj);
        }
        //Update
        protected virtual async Task Update(CreateOrEditModuleDto input)
        {

            var mainObj = await _module.FirstOrDefaultAsync((long)input.Id);
            ObjectMapper.Map(input, mainObj);
        }


        public async Task Delete(EntityDto<long> input)
        {
            var result = await _module.GetAll().FirstOrDefaultAsync(e => e.Id == input.Id);
            await _module.DeleteAsync((long)result.Id);
        }

        public async Task<PagedResultDto<ModuleDto>> GetAll(GetModuleInput input)
        {
            var querry = from LupContModule in _module.GetAll().AsNoTracking()
                         .Where(e => string.IsNullOrWhiteSpace(input.ModuleNo) || e.ModuleNo.Contains(input.ModuleNo))
                         join DvnContList in _suppilerno.GetAll().AsNoTracking()
                         on LupContModule.DevaningNo equals DvnContList.DevaningNo
                         into SuppilerNo
                         from DvnContList in SuppilerNo.DefaultIfEmpty()
                         select new ModuleDto
                         {
                             Id = LupContModule.Id,                             
                             ModuleNo = LupContModule.ModuleNo,
                             DevaningNo = LupContModule.DevaningNo,
                             SuppilerNo = DvnContList.SuppilerNo,
                             ModuleStatus = LupContModule.ModuleStatus,                             
                         };

            var totalCount = await querry.CountAsync();
            var paged = querry.PageBy(input);


            return new PagedResultDto<ModuleDto>(
                totalCount,
                await paged.ToListAsync()
                );
        }

        public async Task<FileDto> GetModuleToExcel(ModuleExportInput input)
        {
            var query = from o in _module.GetAll()
                        select new ModuleDto
                        {
                            Id = o.Id,
                            ModuleNo = o.ModuleNo,
                            DevaningNo = o.DevaningNo,                       
                            
                            ModuleStatus = o.ModuleStatus,
                          
                        };
            var exportToExcel = await query.ToListAsync();
            return _calendarListExcelExporter.ExportToFile(exportToExcel);
        }
    }
}
