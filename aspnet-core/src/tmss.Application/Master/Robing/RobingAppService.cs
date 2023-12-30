using Abp.Application.Services.Dto;
using Abp.Dapper.Repositories;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tmss.Dto;
using tmss.Master.Robing.Dto;
using tmss.Master.Robing.Exporting;
using tmss.Master.Unpacking.Exporting;

namespace tmss.Master.Robing
{
     public class RobingAppService : tmssAppServiceBase, IRobingAppService
    {
        private readonly IRepository<Robings, long> _robing;
        private readonly IDapperRepository<Robings, long> _robingScreen;
        private readonly IRobingExcelExporter _calendarListExcelExporter;
        public RobingAppService(IRepository<Robings, long> robing,
                                     IDapperRepository<Robings, long> robingScreen,
                                     IRobingExcelExporter calendarListExcelExporter
            )

        {

            _robing = robing;
            _robingScreen = robingScreen;
            _calendarListExcelExporter = calendarListExcelExporter;
        }
        public async Task RequestGiveBack(long? id)
        {
            string sql = "UPDATE Robing SET Type = 'PENDING' WHERE id = @Id";
            await _robingScreen.ExecuteAsync(sql, new
            {
                Id = id
            }); ;

        }

        public async Task<List<RobingDto>> GetAllRobing(string partNo)
        {
            var a = await _robingScreen.QueryAsync<RobingDto>(@"select * from Robing where (ISNULL(@partNo, '') = '' OR PartNo LIKE CONCAT('%', @partNo, '%'))", new
            {
                partNo = partNo
            });
            return a.ToList();
        }
        public async Task<FileDto> GetRobingToExcel(string partNo)
        {
            var a = await _robingScreen.QueryAsync<RobingDto>(@"select * from Robing where (ISNULL(@partNo, '') = '' OR PartNo LIKE CONCAT('%', @partNo, '%'))", new
            {
                partNo = partNo
            });
            var exportToExcel =  a.ToList();
            return _calendarListExcelExporter.ExportToFile(exportToExcel);
        }
    }
    }
