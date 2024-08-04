using ShopProjectMVC.Core.Models;

namespace ShopProjectMVC.Core.Interfaces;

public interface IOrderService
{
	IEnumerable<Order> GetAll();
	IEnumerable<Order> GetOrders(int userId);
    IEnumerable<Order> GetOrders(int userId, int offset, int size);
}