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
using tmss.Master.Pc;
using tmss.Master.Unpacking.Dto;
using tmss.Master.Unpacking.Exporting;

namespace tmss.Master.Pc
{
    public class PcStoreAppService : tmssAppServiceBase , IPcStoreAppService
    {
        private readonly IRepository<PcStore, long> _pcstore;


        public PcStoreAppService(IRepository<PcStore, long> pcstore

            )

        {
            _pcstore = pcstore;
        }




        public async Task<PagedResultDto<PcStoreDto>> GetAll(PcStoreInputDto input)
        {
            var querry = from PcStore in _pcstore.GetAll().AsNoTracking()                       
                         select new PcStoreDto
                         {
                             Id = PcStore.Id,
                             PartNo = PcStore.PartNo,
                             PartName = PcStore.PartName,                         
                         };

            var totalCount = await querry.CountAsync();
            var paged = querry.PageBy(input);


            return new PagedResultDto<PcStoreDto>(
                totalCount,
                await paged.ToListAsync()
                );
        }

    }


}
