﻿using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Dapper.Repositories;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore.Uow;
using Abp.Linq.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tmss.Authorization;
using tmss.Dto;
using tmss.Master.DevaningContModule.Dto;
using tmss.Master.DevaningContModule.Exporting;
using tmss.Master.DevaningModule;


namespace tmss.Master.DevaningContModule
{
    
    public class DevaningContModuleAppService : tmssAppServiceBase, IDevaningModuleAppService
    {
        private readonly IRepository<DvnContList, long> _repo;
        private readonly IDevaningContModuleExcelExporter _calendarListExcelExporter;
        //private readonly IRepository<DvnContList, long> _dvcscreen;
        private readonly IDapperRepository<DvnContList, long> _dvcscreen;

        public DevaningContModuleAppService(IRepository<DvnContList, long> repo,
                                        IDevaningContModuleExcelExporter calendarListExcelExporter,
                                        IDapperRepository<DvnContList, long> dvcscreen
            )
        {
            _dvcscreen = dvcscreen;
            _repo = repo;
            _calendarListExcelExporter = calendarListExcelExporter;
        }


        public async Task UpdateOrCreate(DevaningContModuleDto input)
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
        protected virtual async Task Create(DevaningContModuleDto input)
        {
            var mainObj = ObjectMapper.Map<DvnContList>(input);
            await _repo.InsertAsync(mainObj);
        }

        //Update
        protected virtual async Task Update(DevaningContModuleDto input)
        {
            var mainObj = await _repo.FirstOrDefaultAsync((long)input.Id);

            if (mainObj != null)
            {
                ObjectMapper.Map(input, mainObj);
                // You might want to add additional logic for updating related entities or perform other actions
                await _repo.UpdateAsync(mainObj);
            }
            else
            {              
                 throw new EntityNotFoundException(typeof(DvnContList), input.Id);
            }
        }


        //Delete

        public async Task Delete(EntityDto<long> input)
        {            
            var result = await _repo.GetAll().FirstOrDefaultAsync(e => e.Id == input.Id);
            await _repo.DeleteAsync((long)result.Id);
        }


        public async Task<List<DevaningContModuleDto>> GetAll(GetDevaningContModuleInput input)
        {
            var query = _repo.GetAll().AsNoTracking()
                .Where(e => string.IsNullOrWhiteSpace(input.DevaningNo) || e.DevaningNo.Contains(input.DevaningNo))
                .Where(e => string.IsNullOrWhiteSpace(input.DevaningStatus) || e.DevaningStatus.Contains(input.DevaningStatus))
                .Select(DvnContList => new DevaningContModuleDto
                {
                    Id = DvnContList.Id,
                    DevaningNo = DvnContList.DevaningNo,
                    ContainerNo = DvnContList.ContainerNo,
                    Renban = DvnContList.Renban,
                    SuppilerNo = DvnContList.SuppilerNo,
                    ShiftNo = DvnContList.ShiftNo,
                    WorkingDate = DvnContList.WorkingDate,
                    PlanDevaningDate = DvnContList.PlanDevaningDate,
                    ActDevaningDate = DvnContList.ActDevaningDate,
                    ActDevaningDateFinish = DvnContList.ActDevaningDateFinish,
                    DevaningType = DvnContList.DevaningType,
                    DevaningStatus = DvnContList.DevaningStatus,
                });

            return await query.ToListAsync();
        }




        public async Task FinishDvnCont(int dvn_id)
        {
            string _sql = "Exec DEVANT_MODULE @IdDevant";
            await _dvcscreen.QueryAsync<DevaningContModuleDto>(_sql, new { IdDevant = dvn_id });
        }
        public async Task<List<CoutPlanDvn>> GetDevaningPlan()
        {
            string _sqlSearch = "Exec COUNT_DEVANING_WORKINGDATE";

            IEnumerable<CoutPlanDvn> _result = await _dvcscreen.QueryAsync<CoutPlanDvn>(_sqlSearch, new { });
            return _result.ToList();
        }       


        public async Task<FileDto> GetDevaningContModuleToExcel(DevaningContModuleExportInput input)
        {
            var query = from o in _repo.GetAll()
                        select new DevaningContModuleDto
                        {
                            Id = o.Id,
                            DevaningNo = o.DevaningNo,
                            ContainerNo = o.ContainerNo,
                            Renban = o.Renban,
                            SuppilerNo = o.SuppilerNo,
                            ShiftNo = o.ShiftNo,
                            WorkingDate = o.WorkingDate,
                            PlanDevaningDate = o.PlanDevaningDate,
                            ActDevaningDate = o.ActDevaningDate,
                            ActDevaningDateFinish = o.ActDevaningDateFinish,
                            DevaningType = o.DevaningType,
                            DevaningStatus = o.DevaningStatus,
                        };
            var exportToExcel = await query.ToListAsync();
            return _calendarListExcelExporter.ExportToFile(exportToExcel);
        }
       

    }
}
