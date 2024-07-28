using ShopProjectMVC.Core.Models;

namespace ShopProjectMVC.Core.Interfaces;

public interface IOrderService
{
    IEnumerable<Order> GetAll(int userId);
    IEnumerable<Order> GetAll(int userId, int offset, int size);
}