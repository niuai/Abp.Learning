using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Jiabin.Assets
{
    public class AssetRecord : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
