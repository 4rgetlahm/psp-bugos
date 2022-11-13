namespace psp_bugos.Models;

public record BusinessLocation
{
    public Guid Id { get; set; }

    public Guid BusinessId { get; set; }

    public string Name { get; set; } = "";
        
    public string Street { get; set; } = "";
    
    public string City { get; set; } = "";
    
    public string ZipCode { get; set; } = "";
    
    public string PhoneNumber { get; set; } = "";
}