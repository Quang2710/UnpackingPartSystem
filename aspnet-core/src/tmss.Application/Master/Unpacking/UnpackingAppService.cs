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
using tmss.Master.Unpacking.Dto;
using tmss.Master.Unpacking.Exporting;

namespace tmss.Master.Unpacking
{
    public class UnpackingAppService : tmssAppServiceBase, IUnpackingAppService
    {
        private readonly IRepository<LupContModule, long> _unpacking;
        private readonly IUnpackingExcelExporter _calendarListExcelExporter;
        private readonly IDapperRepository<Part, long> _upkscreen;
        private readonly IDapperRepository<LupContModule, long> _getModulePlan;

        public UnpackingAppService(IRepository<LupContModule, long> unpacking,

                                    IUnpackingExcelExporter calendarListExcelExporter,
                                     IDapperRepository<Part, long> upkscreen,
                                       IDapperRepository<LupContModule, long> getModulePlan
            )

        {
            _getModulePlan = getModulePlan;
            _upkscreen = upkscreen;
            _unpacking = unpacking;
            _calendarListExcelExporter = calendarListExcelExporter;
        }

        public async Task CreateOrEdit(CreateOrEditUnpackingDto input)
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

        protected virtual async Task Create(CreateOrEditUnpackingDto input)
        {
            var mainObj = ObjectMapper.Map<LupContModule>(input);
            await _unpacking.InsertAsync(mainObj);
        }

        protected virtual async Task Update(CreateOrEditUnpackingDto input)
        {
            var mainObj = await _unpacking.FirstOrDefaultAsync((long)input.Id);
            ObjectMapper.Map(input, mainObj);
        }
        
        public async Task Delete(EntityDto<long> input)
        {
            var result = await _unpacking.GetAll().FirstOrDefaultAsync(e => e.Id == input.Id);
            await _unpacking.DeleteAsync((long)result.Id);
        }

        public async Task<PagedResultDto<UnpackingDto>> GetAll(GetUnpackingInput input)
        {
            var querry = from LupContModule in _unpacking.GetAll().AsNoTracking()
                         .Where(e => string.IsNullOrWhiteSpace(input.ModuleNo) || e.ModuleNo.Contains(input.ModuleNo))
                         select new UnpackingDto
                         {
                             Id = LupContModule.Id,
                             ModuleNo = LupContModule.ModuleNo,
                             DevaningNo = LupContModule.DevaningNo,
                             Renban = LupContModule.Renban,
                             Supplier = LupContModule.Supplier,
                             ActUnpackingDate = LupContModule.ActUnpackingDate,
                             ActUnpackingDateFinish = LupContModule.ActUnpackingDateFinish,
                             PlanUnpackingDate = LupContModule.PlanUnpackingDate,
                             ModuleStatus = LupContModule.ModuleStatus,                             
                         };

            var totalCount = await querry.CountAsync();
            var paged = querry.PageBy(input);


            return new PagedResultDto<UnpackingDto>(
                totalCount,
                await paged.ToListAsync()
                );
        }

        public async Task<List<PartInModuleDto>> GetPartInModule(string module_no)
        {
            string _sql = "Exec GET_PART_IN_MODULE @ModuleNo";
            IEnumerable<PartInModuleDto> _result = await _upkscreen.QueryAsync<PartInModuleDto>(_sql, new { ModuleNo = module_no });
            return _result.ToList();

        }
        public async Task<List<ModuleUpkPlanDto>> GetModulePlan()
        {
            string _sql = "Exec GET_MODULE_NO_PLAN ";
            IEnumerable<ModuleUpkPlanDto> _result = await _getModulePlan.QueryAsync<ModuleUpkPlanDto>(_sql, new {  });
            return _result.ToList();

        }
        public async Task FinishUpkModule(string module_no)
        {
            string _sql = "Exec FINISH_MODULE @ModuleNo";
            await _getModulePlan.QueryAsync<LupContModule>(_sql, new { ModuleNo = module_no });
        }
        public async Task<FileDto> GetUnpackingToExcel(UnpackingExportInput input)
        {
            var query = from o in _unpacking.GetAll()
                        select new UnpackingDto
                        {
                            Id = o.Id,
                            ModuleNo = o.ModuleNo,
                            DevaningNo = o.DevaningNo,
                            Renban = o.Renban,
                            Supplier = o.Supplier,
                            ActUnpackingDate = o.ActUnpackingDate,
                            ActUnpackingDateFinish = o.ActUnpackingDateFinish,
                            PlanUnpackingDate = o.PlanUnpackingDate,
                            ModuleStatus = o.ModuleStatus,
                            
                        };
            var exportToExcel = await query.ToListAsync();
            return _calendarListExcelExporter.ExportToFile(exportToExcel);
        }
    }

        
    }
