using Abp.Domain.Entities;

namespace tmss.Master.Pc
{ 
    public class PcStoreDto : Entity<long>
    {
        public string PartNo { get; set; }

        public string PartName { get; set; }
     
    }
}
