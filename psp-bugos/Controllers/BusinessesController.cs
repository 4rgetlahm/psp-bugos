using Microsoft.AspNetCore.Mvc;
using psp_bugos.Models;
using psp_bugos.Models.ContinuationTokens;
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

    /** <summary>Get all empployees.</summary>
      * <param name="continuationToken" example="">Token used for pagination(get next top employees)</param>
      * <param name="top" example="100">Number of employees to be returned in one badge. (maximum - 1000)</param>
      * <response code="200">Returns a created business location.</response>
      * <response code="400">Incorrect request: top value larger than 1000 or negative.</response>
      */ 
    [HttpGet]
    [Route("")]
    public ActionResult<ContinuationTokenResult<IEnumerable<BusinessLocation>>> GetAllBusinesses(string? continuationToken = null,[FromQuery] int top = 100)
    {
        if (top > 1000)
            return new BadRequestObjectResult("Top value cannot be greater than 1000");
        if(top < 0)
            return new BadRequestObjectResult("Top value cannot be negative"); 
        
        var businessLocations = new List<BusinessLocation>();
        for (int i = 0; i < top; i++)
        {
            businessLocations.Add(_randomDataGenerator.GenerateValues<BusinessLocation>());
        }

        return new ContinuationTokenResult<IEnumerable<BusinessLocation>>
        {
            Response = businessLocations,
            ContinuationToken = Guid.NewGuid().ToString()
        };
    }
}