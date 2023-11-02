using Abp.Application.Services.Dto;
using Abp.Dapper.Repositories;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tmss.Master.Robing.Dto;

namespace tmss.Master.Robing
{
     public class RobingAppService : tmssAppServiceBase, IRobingAppService
    {
        private readonly IRepository<Robings, long> _robing;
        private readonly IDapperRepository<Robings, long> _robingScreen;

        public RobingAppService(IRepository<Robings, long> robing,
                                     IDapperRepository<Robings, long> robingScreen
            )

        {

            _robing = robing;
            _robingScreen = robingScreen;
        }


        public async Task<List<RobingDto>> GetAllRobing(string partNo)
        {
            var a = await _robingScreen.QueryAsync<RobingDto>(@"select * from Robing where (ISNULL(@partNo, '') = '' OR PartNo LIKE CONCAT('%', @partNo, '%'))", new
            {
                partNo = partNo
            });
            return a.ToList();
        }
    }
    }
