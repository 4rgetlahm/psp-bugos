namespace psp_bugos.Models;

public record Booking
{
    public Guid Id { get; set; }
    
    public Guid BusinessId { get; set; }
    
    public Guid CustomerId { get; set; }

    public string CustomerName { get; set; } = "";

    public string PhoneNumber { get; set; } = "";
    
    public Guid TimeSlotId { get; set; }
    
    public BookingState State { get; set; }
}