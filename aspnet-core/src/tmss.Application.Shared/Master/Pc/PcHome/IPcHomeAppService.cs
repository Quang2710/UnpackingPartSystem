using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace tmss.Master.Pc
{
    public interface IPcHomeAppService : IApplicationService
    {
        Task<List<PcHomeDto>> GetAll(PcHomeInputDto input);


    }
}
