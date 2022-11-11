using Microsoft.AspNetCore.Mvc;
using psp_bugos.Models;
using psp_bugos.RandomDataGenerator;

namespace psp_bugos.Controllers;

[ApiController]
[Route("[controller]")]
public class BusinessController : Controller
{
    private readonly IRandomDataGenerator m_randomDataGenerator;

    public BusinessController(IRandomDataGenerator randomDataGenerator)
    {
        m_randomDataGenerator = randomDataGenerator;
    }

    [HttpGet]
    [Route("")]
    public IEnumerable<BusinessLocation> GetAllBusinesses([FromQuery] int top = 100)
    {
        var businessLocations = new List<BusinessLocation>();
        for (int i = 0; i < top; i++)
        {
            businessLocations.Add(m_randomDataGenerator.GenerateValues<BusinessLocation>());
        }

        return businessLocations;
    }
}