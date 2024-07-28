using ShopProjectMVC.Core.Interfaces;
using ShopProjectMVC.Core.Models;

namespace ShopProjectMVC.Core.Services;

public class OrderService : IOrderService
{
    private readonly IRepository _repository;

    public OrderService(IRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Order> GetAll(int userId)
    {
        return _repository.GetAll<Order>()
            .Where(order => order.User.Id == userId);
    }

    public IEnumerable<Order> GetAll(int userId, int offset, int size)
    {
        return GetAll(userId).Skip(offset)
            .Take(size);
    }
}
