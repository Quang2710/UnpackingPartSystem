using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using vovina.Master.WorkingPattern.Dto;

namespace vovina.Master.WorkingPattern
{

	public interface IMstWptWorkingTimeAppService : IApplicationService
	{

		Task<PagedResultDto<MstWptWorkingTimeDto>> GetAll(GetMstWptWorkingTimeInput input);

		Task CreateOrEdit(CreateOrEditMstWptWorkingTimeDto input);

		Task Delete(EntityDto input);

	}

}
