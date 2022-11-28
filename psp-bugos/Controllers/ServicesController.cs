using Microsoft.AspNetCore.Mvc;
using psp_bugos.Models;
using psp_bugos.Models.ContinuationTokens;
using psp_bugos.Models.Create;
using psp_bugos.Models.Update;
using psp_bugos.RandomDataGenerator;
using psp_bugos.Utilities;
using System.ComponentModel.DataAnnotations;

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
        * <param name="name" example="Barber">Service name.</param>
        * <response code="200">Returned a specific service.</response>
        * <response code="404">No service by the specified name found.</response>
        */
    [HttpGet]
    [Route("find/name/{name}")]
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

    /** <summary>Get services by category.</summary>
        * <param name="category" example="Barbershop">Service category.</param>
        * <param name="continuationToken" example="">Token used for pagination(get next top products).</param>
        * <param name="top" example="100">Number of services to be returned in one badge. (maximum - 1000).</param>
        * <response code="200">Returns services.</response>
        * <response code="400">Incorrect request: top value larger than 1000 or negative.</response>
        */
    [HttpGet]
    [Route("find/category/{category}")]
    public ActionResult<ContinuationTokenResult<IEnumerable<Service>>> GetByCategory(string category, string? continuationToken = null,
        int top = 100)
    {
        if (top > 1000)
            return new BadRequestObjectResult("Top value cannot be greater than 1000");
        if (top < 0)
            return new BadRequestObjectResult("Top value cannot be negative");

        var services = new List<Service>();
        for (int i = 0; i < top; i++)
        {
            services.Add(_randomDataGenerator.GenerateValues<Service>());
        }

        return new ContinuationTokenResult<IEnumerable<Service>>
        {
            Response = services,
            ContinuationToken = Guid.NewGuid().ToString()
        };
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

    /** <summary>Add an existing category to the service.</summary>
     * <param name="id" example="f9299fb1-487a-443b-9b34-c6d08493c04d">Service id.</param>
     * <param name="categoryId" example="aa4a7a53-5e8e-40f7-9e29-4a220bf03f60">Id of an existing category that was created via categories endpoint.</param>
     * <response code="200">Returns a categoryItem.</response>
     */
    [HttpPost]
    [Route("{id}/categories")]
    public ActionResult AddServiceCategory(Guid id, [Required] Guid categoryId)
    {
        var categoryItem = _randomDataGenerator.GenerateValues<CategoryItem>();
        categoryItem.ProductId = null;
        categoryItem.CategoryId = categoryId;
        categoryItem.ServiceId = id;

        return Ok(categoryItem);
    }

    /** <summary>Delete an existing category from the service.</summary>
     * <param name="id" example="f9299fb1-487a-443b-9b34-c6d08493c04d">Service id.</param>
     * <param name="categoryItemId" example="aa4a7a53-5e8e-40f7-9e29-4a220bf03f60">Id of a category item (an id of an object received from POST service/id/categories endpoint).</param>
     * <response code="200"></response>
     */
    [HttpDelete]
    [Route("{id}/categories/{categoryItemId}")]
    public ActionResult RemoveServiceCategory(Guid id, Guid categoryItemId)
    {
        return Ok();
    }

    /** <summary>Get all existing discounts (discountItems) that the service has.</summary>
     * <param name="id" example="f9299fb1-487a-443b-9b34-c6d08493c04d">Service id.</param>
     * <response code="200">Returns discountItems.</response>
     */
    [HttpGet]
    [Route("{id}/discounts")]
    public ActionResult GetServiceDiscounts(Guid id)
    {
        var discountItems = new List<DiscountItem>();

        for (var i = 0; i < 3; ++i)
        {
            var discountItem = _randomDataGenerator.GenerateValues<DiscountItem>();
            discountItem.ProductId = null;
            discountItem.ServiceId = id;

            discountItems.Add(discountItem);
        }

        return Ok(discountItems);
    }

    /** <summary>Add an existing discount to the service.</summary>
     * <param name="id" example="f9299fb1-487a-443b-9b34-c6d08493c04d">Service id.</param>
     * <param name="discountId" example="aa4a7a53-5e8e-40f7-9e29-4a220bf03f60">Id of an existing discount that was created via discounts endpoint.</param>
     * <response code="200">Returns a discountItem.</response>
     */
    [HttpPost]
    [Route("{id}/discounts")]
    public ActionResult AddServiceDiscount(Guid id, [Required] Guid discountId)
    {
        var discountItem = _randomDataGenerator.GenerateValues<DiscountItem>();
        discountItem.ProductId = null;
        discountItem.DiscountId = discountId;
        discountItem.ServiceId = id;

        return Ok(discountItem);
    }

    /** <summary>Delete an existing discount from the service.</summary>
     * <param name="id" example="f9299fb1-487a-443b-9b34-c6d08493c04d">Service id.</param>
     * <param name="discountItemId" example="aa4a7a53-5e8e-40f7-9e29-4a220bf03f60">Id of a discount item (an id of an object received from POST services/id/discounts endpoint).</param>
     * <response code="200"></response>
     */
    [HttpDelete]
    [Route("{id}/discounts/{discountItemId}")]
    public ActionResult RemoveServiceDiscount(Guid id, Guid discountItemId)
    {
        return Ok();
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
      * <param name="timeslotId" example="222b771c-5c2b-436d-8500-783fb5e2edff">GUID of a timeslot's service.</param>
      * <remarks>Note: our mocked service instance has a duration of 15 minutes. Therefore, there will be 15 minute difference between `From` and `To`.</remarks>
      * <response code="200">Returns a modified timeslot.</response>
      */
    [HttpPatch]
    [Route("{id}/timeslot/{timeslotId}")]
    public TimeSlot EditTimeSlot([FromQuery] UpdateTimeSlot updateTimeSlot, Guid id, Guid timeslotId)
    {
        var timeSlot = _randomDataGenerator.GenerateValues<TimeSlot>(timeslotId);
        timeSlot = DtoMapper.MapDtoOnDto(updateTimeSlot, timeSlot);
        timeSlot.ServiceId = id;
        timeSlot.To = timeSlot.From.AddMinutes(15);

        return timeSlot;
    }

    /** <summary>Delete an existing timeslot.</summary>
      * <param name="id" example="111b771c-5c2b-436d-8500-783fb5e2edff">GUID of a timeslot's service.</param>
      * <param name="timeslotId" example="222b771c-5c2b-436d-8500-783fb5e2edff">GUID of a timeslot's service.</param>
      * <response code="200"></response>
      */
    [HttpDelete]
    [Route("{id}/timeslot/{timeslotId}")]
    public ActionResult DeleteTimeSlot(Guid id, Guid timeslotId)
    {
        return Ok();
    }
}