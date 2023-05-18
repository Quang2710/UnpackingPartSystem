using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;

namespace tmss.Master.Pc
{
    public interface IPcHomeAppService : IApplicationService
    {
        Task<PagedResultDto<PcHomeDto>> GetAll(PcHomeInputDto input);


    }
}
