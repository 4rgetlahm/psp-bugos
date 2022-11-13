namespace psp_bugos.Models;

public record Shipment
{
    public Guid Id { get; set; }
    
    public Guid BusinessId { get; set; }
    
    public Guid PaymentId { get; set; }
    
    public Guid TrackingId { get; set; }

    public string Recipient { get; set; } = "";
    
    public string PhoneNo { get; set; } = "";
    
    public string AddressLine1 { get; set; } = "";
    
    public string AddressLine2 { get; set; } = "";
    
    public string City { get; set; } = "";
    
    public string ZipCode { get; set; } = "";
    
    public ShipmentStatus Status { get; set; }
}