using Microsoft.AspNetCore.Mvc;
using psp_bugos.Models;
using psp_bugos.RandomDataGenerator;
using psp_bugos.Utilities;

namespace psp_bugos.Controllers;

[ApiController]
[Route("orders")]
public class OrdersController : Controller
{
    private readonly IRandomDataGenerator _randomDataGenerator;

    public OrdersController(IRandomDataGenerator randomDataGenerator)
    {
        _randomDataGenerator = randomDataGenerator;
    }

    /** <summary>Place order with needed information provided.</summary>
      * <param name="customerId" example="e0299fb1-487a-443b-9b34-c6d08493c04d">Customer id</param>
      * <param name="id" example="f9299fb1-487a-443b-9b34-c6d08493c04d">Order id</param>
      * <param name="type" example="1"> Payment type.</param>
      * <response code="200">Order has been confirmed.</response>
      * <remarks>Note: Currently we need to discuss what is needed information.</remarks>
      */
    [HttpPost]
    [Route("{id}/place")]
    public ActionResult PlaceOrder(Guid customerId, Guid id, PaymentType type)
    {
        // dont know what is "needed information" in the task
        return Ok();
    }

    /** <summary>Place order without registered user.</summary>
      * <param name="locationId" example="e0299fb1-487a-443b-9b34-c6d08493c04d">Location id</param>
      * <param name="id" example="f9299fb1-487a-443b-9b34-c6d08493c04d">Order id</param>
      * <param name="tips" example="10.00"> Tips.</param>
      * <param name="type" example="1"> Payment type.</param>
      * <response code="200">Order has been confirmed.</response>
      * <remarks>Note: Currently we need to discuss what is needed information.</remarks>
      */
    [HttpPost]
    [Route("{id}/place/unregistered")]
    public ActionResult PlaceOrderUnregistered(PaymentType type, Guid id, Guid locationId, decimal tips)
    {
        return Ok();
    }

    /** <summary>Add date to the order</summary>
      * <param name="id" example="f9299fb1-487a-443b-9b34-c6d08493c04d">Order id</param>
      * <param name="date" example="2022-12-24"> Order date.</param>
      * <response code="200">Date has been added to the order.</response>
      */
    [HttpPost]
    [Route("{id}/addDate")]
    public ActionResult AddDateToOrder(Guid id, DateTime date)
    {
        var order = _randomDataGenerator.GenerateValues<Order>(id);
        order.Date = date;
        return Ok(order);
    }

    /** <summary>Add comment to the order</summary>
      * <param name="id" example="f9299fb1-487a-443b-9b34-c6d08493c04d">Order id</param>
      * <param name="comment" example="I want no onions"> Order comments.</param>
      * <response code="200">Comment has been added to the order.</response>
      */
    [HttpPost]
    [Route("{id}/addComment")]
    public ActionResult AddDateToOrder(Guid id, [FromBody] string comment)
    {
        var order = _randomDataGenerator.GenerateValues<OrderItem>(id);
        order.Comment = comment;
        return Ok(order);
    }

    /** <summary>Add employee to the order</summary>
        * <param name="id" example="f9299fb1-487a-443b-9b34-c6d08493c04d">Order id</param>
        * <param name="employeeId" example="f9aaafb1-487a-443b-9b34-c6d08493c04d"> Employee id.</param>
        * <response code="200">Employee has been added to the order.</response>
        */
    [HttpPost]
    [Route("{id}/employee/add/{employeeId}")]
    public ActionResult AddEmployeeToTheOrder(Guid id, Guid employeeId)
    {
        var order = _randomDataGenerator.GenerateValues<Order>(id);
        order.EmployeeId = employeeId;
        return Ok(order);
    }

    /** <summary>Add tips to the order</summary>
    * <param name="id" example="f9299fb1-487a-443b-9b34-c6d08493c04d">Order id</param>
    * <param name="tipAmount" example="2.5">Tip amount</param>
    * <response code="200">Order with added tip.</response>
    */
    [HttpPost]
    [Route("{id}/tip")]
    public ActionResult AddTip(Guid id, decimal tipAmount)
    {
        var order = _randomDataGenerator.GenerateValues<Order>(id);
        order.Tips = tipAmount;
        return Ok(order);
    }

    /** <summary>Confirm the order.</summary>
    * <param name="id" example="f9299fb1-487a-443b-9b34-c6d08493c04d">Order id.</param>
    * <response code="200">Order with updated status.</response>
    */
    [HttpPatch]
    [Route("{id}/confirm")]
    public ActionResult ConfirmOrder(Guid id)
    {
        var order = _randomDataGenerator.GenerateValues<Order>(id);
        order.Status = OrderStatus.Confirmed;
        return Ok(order);
    }

    /** <summary>Create a shipment for the order.</summary>
    * <param name="id" example="f9299fb1-487a-443b-9b34-c6d08493c04d">Order id.</param>
    * <response code="200">Returns created shipment for the order.</response>
    */
    [HttpPost]
    [Route("{id}/createShipment")]
    public ActionResult CreateShipment(Guid id, [FromQuery] CreateShipment createShipment)
    {
        var shipment = _randomDataGenerator.GenerateValues<Shipment>();
        shipment = DtoMapper.MapDtoOnDto(createShipment, shipment);
        shipment.OrderId = id;
        shipment.Status = ShipmentStatus.Created;
        shipment.AddressLine2 = string.IsNullOrEmpty(createShipment.AddressLine2)
            ? ""
            : createShipment.AddressLine2;

        return Ok(shipment);
    }

}