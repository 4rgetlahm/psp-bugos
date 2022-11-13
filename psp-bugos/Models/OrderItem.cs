namespace psp_bugos.Models;

public record OrderItem
{
    public Guid Id { get; set; }
    
    public Guid OrderId { get; set; }
    
    public Guid ProductId { get; set; }
    
    public Guid ServiceId { get; set; }
    
    public int Quantity { get; set; }

    public string Comment { get; set; } = "";
}