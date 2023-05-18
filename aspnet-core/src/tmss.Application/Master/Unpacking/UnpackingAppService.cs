﻿using Abp.Application.Services.Dto;
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
        private readonly IRepository<UnPackingPart, long> _unpacking;
        private readonly IUnpackingExcelExporter _calendarListExcelExporter;
        private readonly IDapperRepository<Part, long> _upkscreen;
        private readonly IDapperRepository<LupContModule, long> _getModulePlan;

        public UnpackingAppService(IRepository<UnPackingPart, long> unpacking,

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
            var mainObj = ObjectMapper.Map<UnPackingPart>(input);
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
            var querry = from UnPackingPart in _unpacking.GetAll().AsNoTracking()
                         .Where(e => string.IsNullOrWhiteSpace(input.UnpackingNo) || e.UnpackingNo.Contains(input.UnpackingNo))
                         select new UnpackingDto
                         {
                             Id = UnPackingPart.Id,
                             UnpackingNo = UnPackingPart.UnpackingNo,
                             ModuleNo = UnPackingPart.ModuleNo,
                             Renban = UnPackingPart.Renban,
                             SuppilerNo = UnPackingPart.SuppilerNo,
                             ShiftNo = UnPackingPart.ShiftNo,
                             WorkingDate = UnPackingPart.WorkingDate,
                             PlanUnpackingDate = UnPackingPart.PlanUnpackingDate,
                             ActUnpackingDate = UnPackingPart.ActUnpackingDate,
                             ActUnpackingDateFinish = UnPackingPart.ActUnpackingDateFinish,
                             UnpackingType = UnPackingPart.UnpackingType,
                             UnpackingStatus = UnPackingPart.UnpackingStatus,
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
                            UnpackingNo = o.UnpackingNo,
                            ModuleNo = o.ModuleNo,
                            Renban = o.Renban,
                            SuppilerNo = o.SuppilerNo,
                            ShiftNo = o.ShiftNo,
                            WorkingDate = o.WorkingDate,
                            PlanUnpackingDate = o.PlanUnpackingDate,
                            ActUnpackingDate = o.ActUnpackingDate,
                            ActUnpackingDateFinish = o.ActUnpackingDateFinish,
                            UnpackingType = o.UnpackingType,
                            UnpackingStatus = o.UnpackingStatus,
                        };
            var exportToExcel = await query.ToListAsync();
            return _calendarListExcelExporter.ExportToFile(exportToExcel);
        }
    }

        
    }
