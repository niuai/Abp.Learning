using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Jiabin.Assets
{
    public class Asset : AuditedAggregateRoot<Guid>
    {
        public virtual string Name { get; set; }

        public virtual string Description { get; set; }
    }
}
