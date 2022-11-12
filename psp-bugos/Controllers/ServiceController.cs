using Microsoft.AspNetCore.Mvc;
using psp_bugos.Models;
using psp_bugos.RandomDataGenerator;

namespace psp_bugos.Controllers;

[ApiController]
[Route("[controller]")]
public class ServiceController : Controller
{
    private readonly IRandomDataGenerator m_randomDataGenerator;

    public ServiceController(IRandomDataGenerator randomDataGenerator)
    {
        m_randomDataGenerator = randomDataGenerator;
    }

    [HttpGet]
    [Route("{name}")]
    public Service Get(string name)
    {
        return m_randomDataGenerator.GenerateValues<Service>();
    }
    
    [HttpGet]
    [Route("{id:guid}")]
    public object Get(Guid id)
    {
        Service result = m_randomDataGenerator.GenerateValues<Service>(id);
        return new {result.Id, result.Description, result.ImageUrl};
    }
    
    [HttpPost]
    [Route("cart/")]
    public IEnumerable<Service> GetCart([FromBody] IEnumerable<Guid> ids)
    {
        return ids.Select(id => m_randomDataGenerator.GenerateValues<Service>(id));
    }
    
    [HttpPost]
    [Route("cart/add/{id:guid}")]
    public ActionResult AddServiceToCart(Guid id, [FromBody] Booking booking)
    {
        return Ok();
    }
    
    [HttpPatch]
    [Route("cart/update/{id:guid}")]
    public ActionResult UpdateServiceInCart(Guid id, [FromBody] Booking booking)
    {
        return Ok();
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