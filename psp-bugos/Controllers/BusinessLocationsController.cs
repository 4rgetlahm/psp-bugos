using Microsoft.AspNetCore.Mvc;
using psp_bugos.Models;
using psp_bugos.Models.Create;
using psp_bugos.Models.Update;
using psp_bugos.RandomDataGenerator;
using psp_bugos.Utilities;
using System.ComponentModel.DataAnnotations;

namespace psp_bugos.Controllers;

[ApiController]
[Route("businessLocations")]
public class BusinessLocationsController : Controller
{
    private readonly IRandomDataGenerator _randomDataGenerator;

    public BusinessLocationsController(IRandomDataGenerator randomDataGenerator)
    {
        _randomDataGenerator = randomDataGenerator;
    }
    
    /** <summary>Create a business location.</summary>
      * <response code="200">Returns a created business location.</response>
      */
    [HttpPost]
    public BusinessLocation CreateLocation([FromQuery] CreateBusinessLocation createBusinessLocation)
    {
        var businessLocation = _randomDataGenerator.GenerateValues<BusinessLocation>();
        return DtoMapper.MapDtoOnDto(createBusinessLocation, businessLocation);
    }

    /** <summary>Update an existing business location.</summary>
      * <response code="200">Returns a modified business location.</response>
      */
    [HttpPatch]
    [Route("{id}")]
    public BusinessLocation UpdateLocation([FromQuery] UpdateBussinessLocation updateBusinessLocation, Guid id)
    {
        var businessLocation = _randomDataGenerator.GenerateValues<BusinessLocation>(id);
        return DtoMapper.MapDtoOnDto(updateBusinessLocation, businessLocation);
    }

    /** <summary>Delete an existing business location.</summary>
      * <param name="id" example="f9299fb1-487a-443b-9b34-c6d08493c04d">Business location id.</param>
      */
    [HttpDelete]
    [Route("{id}")]
    public ActionResult DeleteLocation(Guid id)
    {
        return Ok();
    }
}