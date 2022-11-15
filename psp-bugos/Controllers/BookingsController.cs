using Microsoft.AspNetCore.Mvc;
using psp_bugos.Models;
using psp_bugos.RandomDataGenerator;

namespace psp_bugos.Controllers
{
    [ApiController]
    [Route("bookings")]
    public class BookingsController : Controller
    {
        private readonly IRandomDataGenerator _randomDataGenerator;

        public BookingsController(IRandomDataGenerator randomDataGenerator)
        {
            _randomDataGenerator = randomDataGenerator;
        }

        /** <summary>Confirm a booking and notify its customer about it.</summary>
         * <param name="id" example="aa4a7a53-5e8e-40f7-9e29-4a220bf03f60">GUID of the booking.</param>
         * <response code="200">Returns a modified booking with updated state.</response>
         */
        [HttpPatch]
        [Route("{id}/confirm")]
        public Booking ConfirmBooking(Guid id)
        {
            var booking =_randomDataGenerator.GenerateValues<Booking>(id);
            booking.State = BookingState.Confirmed;

            return booking;
        }

        /** <summary>Grant a customer a refund for a booking he has made.</summary>
         * <param name="id" example="aa4a7a53-5e8e-40f7-9e29-4a220bf03f60">GUID of the booking.</param>
         * <response code="200">Returns a modified booking with updated state.</response>
         */
        [HttpPatch]
        [Route("{id}/refund")]
        public Booking RefundBooking(Guid id)
        {
            var booking = _randomDataGenerator.GenerateValues<Booking>(id);
            booking.State = BookingState.Refunded;

            return booking;
        }

        /** <summary>Cancel a booking.</summary>
         * <param name="id" example="aa4a7a53-5e8e-40f7-9e29-4a220bf03f60">GUID of the booking.</param>
         * <response code="200">Returns a modified booking with updated state.</response>
         */
        [HttpPatch]
        [Route("{id}/cancel")]
        public Booking CancelBooking(Guid id)
        {
            var booking = _randomDataGenerator.GenerateValues<Booking>(id);
            booking.State = BookingState.Cancelled;

            return booking;
        }

        /** <summary>Reschedule a booking.</summary>
          * <param name="id" example="aa4a7a53-5e8e-40f7-9e29-4a220bf03f60">GUID of the booking.</param>
          * <response code="200">Returns a modified booking with updated state.</response>
          */
        [HttpPatch]
        [Route("{id}/reschedule")]
        public Booking RescheduleBooking(Guid id)
        {
            var booking = _randomDataGenerator.GenerateValues<Booking>(id);
            booking.State = BookingState.Recheduled;

            return booking;
        }

        /** <summary>Complete a booking, indicating that a client has arrived.</summary>
          * <param name="id" example="aa4a7a53-5e8e-40f7-9e29-4a220bf03f60">GUID of the booking.</param>
          * <response code="200">Returns a modified booking with updated state.</response>
          */
        [HttpPatch]
        [Route("{id}/complete")]
        public Booking CompleteBooking(Guid id)
        {
            var booking = _randomDataGenerator.GenerateValues<Booking>(id);
            booking.State = BookingState.ClientArrived;

            return booking;
        }


    }
}
