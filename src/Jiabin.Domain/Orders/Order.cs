using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Jiabin.Orders
{
    public class Order : AuditedAggregateRoot<Guid>
    {
        public string Description { get; set; }
    }
}
