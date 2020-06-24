using System;
using Volo.Abp.Domain.Repositories;

namespace Jiabin.Orders
{
    public interface IOrderRepository : IRepository<Order, Guid>
    {
    }
}
