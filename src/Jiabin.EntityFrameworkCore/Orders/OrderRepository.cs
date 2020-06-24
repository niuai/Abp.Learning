using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Jiabin.Orders
{
    public class OrderRepository : EfCoreRepository<OrderContext, Order, Guid>, IOrderRepository
    {
        public OrderRepository(IDbContextProvider<OrderContext> dbContextProvider) : base(dbContextProvider) { }
    }
}
