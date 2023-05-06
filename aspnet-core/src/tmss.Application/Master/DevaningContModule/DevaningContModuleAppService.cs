﻿using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore.Uow;
using Abp.Linq.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
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
using static tmss.tmssDashboardCustomizationConsts;


namespace tmss.Master.DevaningContModule
{
    
    public class DevaningContModuleAppService : tmssAppServiceBase, IDevaningModuleAppService
    {
        private readonly IRepository<DvnContList, long> _repo;
        private readonly IDevaningContModuleExcelExporter _calendarListExcelExporter;

        public DevaningContModuleAppService(IRepository<DvnContList, long> repo,
                                        IDevaningContModuleExcelExporter calendarListExcelExporter
            )
        {
            _repo = repo;
            _calendarListExcelExporter = calendarListExcelExporter;
        }

        
        public async Task CreateOrEdit(CreateOrEditDevaningContModuleDto input)
        {
            if (input.Id == null) await Create(input);
            else await Update(input);
        }

        //Create
        protected virtual async Task Create(CreateOrEditDevaningContModuleDto input)
        {
            var mainObj = ObjectMapper.Map<DvnContList>(input);

            //await CurrentUnitOfWork.GetDbContext<DbContext>().AddAsync(mainObj);
            await _repo.InsertAsync(mainObj);
        }
        //Update
        protected virtual async Task Update(CreateOrEditDevaningContModuleDto input)
        {
            //using (CurrentUnitOfWork.DisableFilter(AbpDataFilters.MayHaveTenant))
            //{
            //    var mainObj = await _repo.GetAll()
            //    .FirstOrDefaultAsync(e => e.Id == input.Id);

            //    var mainObjToUpdate = ObjectMapper.Map(input, mainObj);
            //}

            var mainObj = await _repo.FirstOrDefaultAsync((long)input.Id);
            ObjectMapper.Map(input,mainObj);
        }

        

        //Delete
        
        public async Task Delete(EntityDto input)
        {
            //var mainObj = await _repo.FirstOrDefaultAsync(input.Id);
            //CurrentUnitOfWork.GetDbContext<DbContext>().Remove(mainObj);

            var result = await _repo.GetAll().FirstOrDefaultAsync(e => e.Id == input.Id);
            await _repo.DeleteAsync((long)result.Id);
        }
        //GetAll
        //public async Task<PagedResultDto<DevaningContModuleDto>> GetAll(GetDevaningContModuleModuleInput input)
        //{
        //    var filtered = _repo.GetAll()
        //        .WhereIf(!string.IsNullOrWhiteSpace(input.ContainerNo), e => e.ContainerNo.Contains(input.ContainerNo))
        //        .WhereIf(!string.IsNullOrWhiteSpace(input.Renban), e => e.Renban.Contains(input.Renban))
        //        .WhereIf(!string.IsNullOrWhiteSpace(input.SuppilerNo), e => e.SuppilerNo.Contains(input.SuppilerNo))
        //        .WhereIf(!string.IsNullOrWhiteSpace(input.DevaningStatus), e => e.DevaningStatus.Contains(input.DevaningStatus))
        //        ;
        //    var pageAndFiltered = filtered.OrderBy(s => s.Id);


        //    var system = from o in pageAndFiltered
        //                 select new DevaningContModuleDto
        //                 {
        //                     Id = o.Id,
        //                     DevaningNo = o.DevaningNo,
        //                     ContainerNo = o.ContainerNo,
        //                     Renban = o.Renban,
        //                     SuppilerNo = o.SuppilerNo,
        //                     ShiftNo = o.ShiftNo,
        //                     WorkingDate = o.WorkingDate,
        //                     PlanDevaningDate = o.PlanDevaningDate,
        //                     ActDevaningDate = o.ActDevaningDate,
        //                     ActDevaningDateFinish = o.ActDevaningDateFinish,
        //                     DevaningType = o.DevaningType,
        //                     DevaningStatus = o.DevaningStatus,
        //                 };

        //    var totalCount = await filtered.CountAsync();
        //    var paged = system.PageBy(input);


        //    return new PagedResultDto<DevaningContModuleDto>(
        //        totalCount,
        //        await paged.ToListAsync()
        //    );

        //}


        public async Task<PagedResultDto<DevaningContModuleDto>> GetAll(GetDevaningContModuleModuleInput input)
        {
            var querry = from DvnContList in _repo.GetAll().AsNoTracking()
                         .Where(e => string.IsNullOrWhiteSpace(input.DevaningNo) || e.DevaningNo.Contains(input.DevaningNo))
                         select new DevaningContModuleDto
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
                         };

                var totalCount = await querry.CountAsync();
                var paged = querry.PageBy(input);


                return new PagedResultDto<DevaningContModuleDto>(
                    totalCount,
                    await paged.ToListAsync()
                    );

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