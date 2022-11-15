using Microsoft.AspNetCore.Mvc;
using psp_bugos.Models;
using psp_bugos.Models.Create;
using psp_bugos.Models.Update;
using psp_bugos.RandomDataGenerator;
using psp_bugos.Utilities;

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

    /** <summary>Get service by name.</summary>
        * <param name="name" example="banana">Service name.</param>
        * <response code="200">Returned a specific service.</response>
        * <response code="404">No service by the specified name found.</response>
        */
    [HttpGet]
    [Route("{name}")]
    public Service Get(string name)
    {
        return _randomDataGenerator.GenerateValues<Service>();
    }

    /** <summary>Get service description.</summary>
        * <param name="id" example="f9299fb1-487a-443b-9b34-c6d08493c04d">Service id.</param>
        * <response code="200">Returned a specific service description.</response>
        * <response code="404">No services by specific id found.</response>
        */
    [HttpGet]
    [Route("{id:guid}")]
    public object Get(Guid id)
    {
        var result = _randomDataGenerator.GenerateValues<Service>(id);
        return new {result.Id, result.Description, result.ImageUrl};
    }

    /** <summary>Get services cart.</summary>
        * <param name="ids" >Service ids in the cart.</param>
        * <response code="200">Returned cart data successfully.</response>
        */
    [HttpPost]
    [Route("cart/")]
    public IEnumerable<Service> GetCart([FromBody] IEnumerable<Guid> ids)
    {
        return ids.Select(id => _randomDataGenerator.GenerateValues<Service>(id));
    }

    /** <summary>Add service to cart.</summary>
        * <param name="id" example="f9299fb1-487a-443b-9b34-c6d08493c04d">Product id.</param>
        * <response code="200">Returned cart data successfully.</response>
        * <response code="404">Service not found.</response>
            */
    [HttpPost]
    [Route("cart/add/{id:guid}")]
    public ActionResult AddServiceToCart(Guid id, [FromBody] Booking booking)
    {
        var orderItem = _randomDataGenerator.GenerateValues<OrderItem>();
        orderItem.ServiceId = id;
        return Ok(orderItem);
    }

    /** <summary>Update services in a cart.</summary>
        * <param name="id" example="f9299fb1-487a-443b-9b34-c6d08493c04d">Service id.</param>
        * <response code="200">Returned cart data successfully.</response>
        * <response code="404">Service not found.</response>
        */
    [HttpPatch]
    [Route("cart/update/{id:guid}")]
    public ActionResult UpdateServiceInCart(Guid id, [FromBody] Booking booking)
    {
        var orderItem = _randomDataGenerator.GenerateValues<OrderItem>();
        orderItem.ServiceId = id;
        return Ok(orderItem);
    }

    /** <summary>Remove service in a cart.</summary>
        * <param name="id" example="f9299fb1-487a-443b-9b34-c6d08493c04d">Service id.</param>
        * <response code="200">Returned cart data successfully.</response>
        * <response code="404">Service not found.</response>
        */
    [HttpDelete]
    [Route("cart/remove/{id:guid}")]
    public ActionResult RemoveServiceFromCart(Guid id)
    {
        return Ok();
    }

    /** <summary>Provide service information</summary>
        * <param name="id" example="f9299fb1-487a-443b-9b34-c6d08493c04d">Service id.</param>
        * <response code="200">Provided information about service.</response>
        * <response code="404">Service not found.</response>
        */
    [HttpPost]
    [Route("provideInformation")]
    public ActionResult ProvideInformation(Guid id, [FromBody] string information)
    {
        // dont know what is "needed information" in the task, so I'll leave it as string
        return Ok();
    }

    /** <summary>Create a new service.</summary>
      * <response code="200">Returns a created service.</response>
      */
    [HttpPost]
    public Service CreateService([FromQuery] CreateService createService)
    {
        var service = _randomDataGenerator.GenerateValues<Service>();
        return DtoMapper.MapDtoOnDto(createService, service);
    }

    /** <summary>Update an existing service.</summary>
      * <response code="200">Returns a modified service.</response>
      */
    [HttpPatch]
    [Route("{id}")]
    public Service UpdateService([FromQuery] UpdateService updateService, Guid id)
    {
        var service = _randomDataGenerator.GenerateValues<Service>(id);
        return DtoMapper.MapDtoOnDto(updateService, service);
    }

    /** <summary>Create a new timeslot.</summary>
      * <param name="id" example="111b771c-5c2b-436d-8500-783fb5e2edff">GUID of a service for which timeslot is being created.</param>
      * <remarks>Note: our mocked service instance has a duration of 15 minutes. Therefore, there will be 15 minute difference between `From` and `To`.</remarks>
      * <response code="200">Returns a created timeslot.</response>
      */
    [HttpPost]
    [Route("{id}/timeslot")]
    public TimeSlot CreateTimeSlot([FromQuery] CreateTimeSlot createTimeSlot, Guid id)
    {
        var timeSlot = _randomDataGenerator.GenerateValues<TimeSlot>();
        timeSlot = DtoMapper.MapDtoOnDto(createTimeSlot, timeSlot);
        timeSlot.ServiceId = id;
        timeSlot.To = createTimeSlot.From.AddMinutes(15);

        return timeSlot;
    }

    /** <summary>Update an existing timeslot.</summary>
      * <param name="id" example="111b771c-5c2b-436d-8500-783fb5e2edff">GUID of a timeslot's service.</param>
      * <param name="timeSlotId" example="222b771c-5c2b-436d-8500-783fb5e2edff">GUID of a timeslot's service.</param>
      * <remarks>Note: our mocked service instance has a duration of 15 minutes. Therefore, there will be 15 minute difference between `From` and `To`.</remarks>
      * <response code="200">Returns a modified timeslot.</response>
      */
    [HttpPatch]
    [Route("{id}/timeslot/{timeSlotId}")]
    public TimeSlot CreateTimeSlot([FromQuery] UpdateTimeSlot updateTimeSlot, Guid id, Guid timeSlotId)
    {
        var timeSlot = _randomDataGenerator.GenerateValues<TimeSlot>(timeSlotId);
        timeSlot = DtoMapper.MapDtoOnDto(updateTimeSlot, timeSlot);
        timeSlot.ServiceId = id;
        timeSlot.To = timeSlot.From.AddMinutes(15);

        return timeSlot;
    }
}