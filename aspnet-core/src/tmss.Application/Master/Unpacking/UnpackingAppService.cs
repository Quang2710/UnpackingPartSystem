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
using tmss.Master.Robing.Dto;
using tmss.Master.Unpacking.Dto;
using tmss.Master.Unpacking.Exporting;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

        public async Task<List<UnpackingDto>> GetAll(GetUnpackingInput input)
        {
            var query = _unpacking.GetAll().AsNoTracking()
                .Where(e => string.IsNullOrWhiteSpace(input.ModuleNo) || e.ModuleNo.Contains(input.ModuleNo))
                .Where(e => string.IsNullOrWhiteSpace(input.ModuleStatus) || e.ModuleStatus.Contains(input.ModuleStatus))
                .Select(LupContModule => new UnpackingDto
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
                });

            return await query.ToListAsync();
        }

        public async Task<List<PartListDto>> GetAllPartList(string partNo, string moduleNo, string status)
        {
            var a = await _upkscreen.QueryAsync<PartListDto>(
                @"select * from Part where (ISNULL(@partNo, '') = '' OR PartNo LIKE CONCAT('%', @partNo, '%')) and (ISNULL(@moduleNo, '') = '' OR ModuleNo LIKE CONCAT('%', @moduleNo, '%')) and  (ISNULL(@status, '') = '' OR Status LIKE CONCAT('%', @status, '%'))", new
            {
                partNo = partNo,
                moduleNo = moduleNo,
                status = status
            });
            return a.ToList();
        }
        public async Task<FileDto> GetAllPartListExcel(string partNo,string moduleNo, string status)
        {
            var a = await _upkscreen.QueryAsync<PartListDto>(
                @"select * from Part where (ISNULL(@partNo, '') = '' OR PartNo LIKE CONCAT('%', @partNo, '%')) and (ISNULL(@moduleNo, '') = '' OR ModuleNo LIKE CONCAT('%', @moduleNo, '%')) and  (ISNULL(@status, '') = '' OR Status LIKE CONCAT('%', @status, '%'))", new
                {
                    partNo = partNo,
                    moduleNo = moduleNo,
                    status = status
                });
            var exportToExcel = a.ToList();
            return _calendarListExcelExporter.ExportToFilePartList(exportToExcel);
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
        public async Task FinishPart(long? id)
        {
            string sql = "UPDATE Part SET Status = 'FINISH' WHERE id = @Id";
            await _upkscreen.ExecuteAsync(sql, new
            {
                Id = id
            }); ;            

        }
        public async Task AddPartToRobbing(long Id, string PartNo,string PartName, string Supplier , string ModuleNo ,string Type , string Description)
        {
            string _sql = "Exec ADD_PART_TO_ROBBING @p_id ,@p_partNo ,@p_partName,@p_supplier ,@p_moduleNo,@p_type ,@p_description";
            await _getModulePlan.QueryAsync<LupContModule>(_sql, new 
            {
                p_id = Id,
                p_partNo = PartNo,
                p_partName = PartName,
                p_supplier = Supplier,
                p_moduleNo = ModuleNo,
                p_type = Type,
                p_description = Description,
            });
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
