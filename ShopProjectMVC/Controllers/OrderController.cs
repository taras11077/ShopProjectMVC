using Microsoft.AspNetCore.Mvc;
using ShopProjectMVC.Core.Interfaces;
using ShopProjectMVC.Core.Services;

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
        var orders = _orderService.GetAll(1);
        return View(orders);
    }
}

