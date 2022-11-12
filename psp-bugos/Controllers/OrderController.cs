using Microsoft.AspNetCore.Mvc;
using psp_bugos.Models;
using psp_bugos.RandomDataGenerator;

namespace psp_bugos.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : Controller
{
    private readonly IRandomDataGenerator m_randomDataGenerator;

    public OrderController(IRandomDataGenerator randomDataGenerator)
    {
        m_randomDataGenerator = randomDataGenerator;
    }

    [HttpPost]
    public ActionResult ConfirmOrder(PaymentType type, Guid orderId)
    {
        // dont know what is "needed information" in the task
        return Ok();
    }
    
    [HttpPost]
    public ActionResult ConfirmOrderUnregistered(PaymentType type, Guid orderId, Guid locationId, decimal tips)
    {
        return Ok();
    }
    
    [HttpPost]
    public ActionResult AddDateToOrder(Guid orderId, DateTime date)
    {
        return Ok();
    }
    
}