using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace tmss.Master.Pc
{
    public class PcHomeAppService : tmssAppServiceBase , IPcHomeAppService
    {
        private readonly IRepository<PcHome, long> _pchome;


        public PcHomeAppService(IRepository<PcHome, long> pchome

            )

        {
            _pchome = pchome;
        }




        public async Task<List<PcHomeDto>> GetAll(PcHomeInputDto input)
        {
            var query = _pchome.GetAll().AsNoTracking()
                .Select(PcStore => new PcHomeDto
                {
                    Id = PcStore.Id,
                    PartNo = PcStore.PartNo,
                    PartName = PcStore.PartName,
                });

            return await query.ToListAsync();
        }


    }


}
