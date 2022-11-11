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
        return Ok();
    }
}