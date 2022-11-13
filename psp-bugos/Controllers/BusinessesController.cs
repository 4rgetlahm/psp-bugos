using Microsoft.AspNetCore.Mvc;
using psp_bugos.Models;
using psp_bugos.RandomDataGenerator;

namespace psp_bugos.Controllers;

[ApiController]
[Route("businesses")]
public class BusinessesController : Controller
{
    private readonly IRandomDataGenerator _randomDataGenerator;

    public BusinessesController(IRandomDataGenerator randomDataGenerator)
    {
        _randomDataGenerator = randomDataGenerator;
    }

    [HttpGet]
    [Route("")]
    public IEnumerable<BusinessLocation> GetAllBusinesses([FromQuery] int top = 100)
    {
        var businessLocations = new List<BusinessLocation>();
        for (int i = 0; i < top; i++)
        {
            businessLocations.Add(_randomDataGenerator.GenerateValues<BusinessLocation>());
        }

        return businessLocations;
    }
}