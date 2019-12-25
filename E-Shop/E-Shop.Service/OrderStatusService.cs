namespace E_Shop.Service
{
    using System.Collections.Generic;
    using System.Linq;

    using Data.Repositories;
    using Model;

    public interface IOrderStatusService
    {
        List<OrderStatus> GetOrderStatuses();
    }

    public class OrderStatusService : IOrderStatusService
    {
        private readonly IOrderStatusRepository _orderStatusRepository;

        public OrderStatusService(IOrderStatusRepository orderStatusRepository)
        {
            _orderStatusRepository = orderStatusRepository;
        }

        public List<OrderStatus> GetOrderStatuses()
        {
            var orderStatuses = _orderStatusRepository.GetAll().ToList();
            return orderStatuses;
        }
    }
}
