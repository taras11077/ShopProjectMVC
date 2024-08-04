using Microsoft.AspNetCore.Mvc;
using ShopProjectMVC.Core.Interfaces;
using ShopProjectMVC.Core.Models;

namespace ShopProjectMVC.Controllers;

public class OrderController : Controller
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public IActionResult Index()
    {
	    var orders = new List<Order>();

	    if (HttpContext.Session.GetInt32("role").Value == 1)
	    {
		    orders = _orderService.GetAll().ToList();
		}
		else
		{
			int userId = HttpContext.Session.GetInt32("id").Value;
			orders = _orderService.GetOrders(userId).ToList();
		}

        return View(orders);
    }
}

