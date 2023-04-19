using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore.Uow;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using tmss.Authorization;
using tmss.Dto;
using tmss.Master.WorkingPattern;
using tmss.Master.WorkingPattern.Dto;
using tmss.Master.WorkingPattern.Exporting;

namespace tmss.Master.WorkingPattern
{
    [AbpAuthorize(AppPermissions.Pages_Master_WorkingPattern_WorkingTime)]
    public class MstWptWorkingTimeAppService : tmssAppServiceBase, IMstWptWorkingTimeAppService
    {
        private readonly IRepository<MstWptWorkingTime, long> _repo;
        private readonly IMstWptWorkingTimeExcelExporter _calendarListExcelExporter;

        public MstWptWorkingTimeAppService(IRepository<MstWptWorkingTime, long> repo,
                                        IMstWptWorkingTimeExcelExporter calendarListExcelExporter
            )
        {
            _repo = repo;
            _calendarListExcelExporter = calendarListExcelExporter;
        }

        [AbpAuthorize(AppPermissions.Pages_Master_WorkingPattern_WorkingTime_CreateEdit)]
        public async Task CreateOrEdit(CreateOrEditMstWptWorkingTimeDto input)
        {
            if (input.Id == null) await Create(input);
            else await Update(input);
        }

        //CREATE
        private async Task Create(CreateOrEditMstWptWorkingTimeDto input)
        {
            var mainObj = ObjectMapper.Map<MstWptWorkingTime>(input);

            await CurrentUnitOfWork.GetDbContext<DbContext>().AddAsync(mainObj);
        }

        // EDIT
        private async Task Update(CreateOrEditMstWptWorkingTimeDto input)
        {
            using (CurrentUnitOfWork.DisableFilter(AbpDataFilters.MayHaveTenant))
            {
                var mainObj = await _repo.GetAll()
                .FirstOrDefaultAsync(e => e.Id == input.Id);

                var mainObjToUpdate = ObjectMapper.Map(input, mainObj);
            }
        }

        [AbpAuthorize(AppPermissions.Pages_Master_WorkingPattern_WorkingTime_Delete)]
        public async Task Delete(EntityDto input)
        {
            var mainObj = await _repo.FirstOrDefaultAsync(input.Id);
            CurrentUnitOfWork.GetDbContext<DbContext>().Remove(mainObj);
        }

        public async Task<PagedResultDto<MstWptWorkingTimeDto>> GetAll(GetMstWptWorkingTimeInput input)
        {
            var filtered = _repo.GetAll()
                .WhereIf(!string.IsNullOrWhiteSpace(input.Description), e => e.Description.Contains(input.Description))
                .WhereIf(!string.IsNullOrWhiteSpace(input.SeasonType), e => e.SeasonType.Contains(input.SeasonType))
                .WhereIf(!string.IsNullOrWhiteSpace(input.DayOfWeek), e => e.DayOfWeek.Contains(input.DayOfWeek))
                .WhereIf(!string.IsNullOrWhiteSpace(input.IsActive), e => e.IsActive.Contains(input.IsActive))
                ;
            var pageAndFiltered = filtered.OrderBy(s => s.Id);


            var system = from o in pageAndFiltered
                         select new MstWptWorkingTimeDto
                         {
                             Id = o.Id,
                             ShiftNo = o.ShiftNo,
                             ShopId = o.ShopId,
                             WorkingType = o.WorkingType,
                             StartTime = o.StartTime,
                             EndTime = o.EndTime,
                             Description = o.Description,
                             PatternHId = o.PatternHId,
                             SeasonType = o.SeasonType,
                             DayOfWeek = o.DayOfWeek,
                             WeekWorkingDays = o.WeekWorkingDays,
                             IsActive = o.IsActive,
                         };

            var totalCount = await filtered.CountAsync();
            var paged = system.PageBy(input);

            return new PagedResultDto<MstWptWorkingTimeDto>(
                totalCount,
                 await paged.ToListAsync()
            );
        }


        public async Task<FileDto> GetWorkingTimeToExcel(MstWptWorkingTimeExportInput input)
        {
            var query = from o in _repo.GetAll()
                        select new MstWptWorkingTimeDto
                        {
                            Id = o.Id,
                            ShiftNo = o.ShiftNo,
                            ShopId = o.ShopId,
                            WorkingType = o.WorkingType,
                            StartTime = o.StartTime,
                            EndTime = o.EndTime,
                            Description = o.Description,
                            PatternHId = o.PatternHId,
                            SeasonType = o.SeasonType,
                            DayOfWeek = o.DayOfWeek,
                            WeekWorkingDays = o.WeekWorkingDays,
                            IsActive = o.IsActive,
                        };
            var exportToExcel = await query.ToListAsync();
            return _calendarListExcelExporter.ExportToFile(exportToExcel);
        }

    }
}
