using Microsoft.AspNetCore.Mvc;
using psp_bugos.Models;
using psp_bugos.RandomDataGenerator;

namespace psp_bugos.Controllers;

[ApiController]
[Route("orders")]
public class OrdersController : Controller
{
    private readonly IRandomDataGenerator _randomDataGenerator;
    
    public OrdersController(IRandomDataGenerator randomDataGenerator)
    {
        _randomDataGenerator = randomDataGenerator;
    }
    
    [HttpPost]
    [Route("{orderId}/confirm")]
    public ActionResult ConfirmOrder(PaymentType type, Guid orderId)
    {
        // dont know what is "needed information" in the task
        return Ok();
    }

    [HttpPost]
    [Route("{orderId}/confirm/unregistered")]
    public ActionResult ConfirmOrderUnregistered(PaymentType type, Guid orderId, Guid locationId, decimal tips)
    {
        return Ok();
    }

    [HttpPost]
    [Route("{orderId}/addDate")]
    public ActionResult AddDateToOrder(Guid orderId, DateTime date)
    {
        var order= _randomDataGenerator.GenerateValues<Order>(orderId);
        order.Date = date;
        return Ok(order);
    }

    [HttpPost]
    [Route("{orderId}/employee/add/{employeeId}")]
    public ActionResult AddEmployeeToTheOrder(Guid orderId, Guid employeeId)
    {
        var order= _randomDataGenerator.GenerateValues<Order>(orderId);
        order.EmployeeId = employeeId;
        return Ok(order);
    }
}