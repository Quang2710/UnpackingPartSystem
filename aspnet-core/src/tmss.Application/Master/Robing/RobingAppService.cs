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
     

        public async Task<List<RobingDto>> GetPartInModule(string module_no)
        {
            string _sql = "Exec GET_PART_IN_MODULE @ModuleNo";
            IEnumerable<RobingDto> _result = await _robingScreen.QueryAsync<RobingDto>(_sql, new { ModuleNo = module_no });
            return _result.ToList();

        }
    }
    }
