using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;

namespace tmss.Master.Pc
{
    public interface IPcStoreAppService : IApplicationService
    {
        Task<PagedResultDto<PcStoreDto>> GetAll();
      
    }
}
