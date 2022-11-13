using Microsoft.AspNetCore.Mvc;
using psp_bugos.Models;
using psp_bugos.RandomDataGenerator;

namespace psp_bugos.Controllers;

[ApiController]
[Route("services")]
public class ServicesController : Controller
{
    private readonly IRandomDataGenerator _randomDataGenerator;

    public ServicesController(IRandomDataGenerator randomDataGenerator)
    {
        _randomDataGenerator = randomDataGenerator;
    }

    [HttpGet]
    [Route("{name}")]
    public Service Get(string name)
    {
        return _randomDataGenerator.GenerateValues<Service>();
    }

    [HttpGet]
    [Route("{id:guid}")]
    public object Get(Guid id)
    {
        var result = _randomDataGenerator.GenerateValues<Service>(id);
        return new {result.Id, result.Description, result.ImageUrl};
    }

    [HttpPost]
    [Route("cart/")]
    public IEnumerable<Service> GetCart([FromBody] IEnumerable<Guid> ids)
    {
        return ids.Select(id => _randomDataGenerator.GenerateValues<Service>(id));
    }

    [HttpPost]
    [Route("cart/add/{id:guid}")]
    public ActionResult AddServiceToCart(Guid id, [FromBody] Booking booking)
    {
        var orderItem = _randomDataGenerator.GenerateValues<OrderItem>();
        orderItem.ServiceId = id;
        return Ok(orderItem);
    }

    [HttpPatch]
    [Route("cart/update/{id:guid}")]
    public ActionResult UpdateServiceInCart(Guid id, [FromBody] Booking booking)
    {
        var orderItem = _randomDataGenerator.GenerateValues<OrderItem>();
        orderItem.ServiceId = id;
        return Ok(orderItem);
    }

    [HttpDelete]
    [Route("cart/remove/{id:guid}")]
    public ActionResult RemoveServiceFromCart(Guid id)
    {
        return Ok();
    }

    [HttpPost]
    [Route("provideInformation")]
    public ActionResult ProvideInformation([FromBody] string information)
    {
        // dont know what is "needed information" in the task, so I'll leave it as string
        return Ok();
    }
}