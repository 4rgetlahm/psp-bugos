namespace psp_bugos.Models;

public class DiscountItem
{
    public Guid Id { get; set; }
    
    public Guid DiscountId { get; set; }
    
    public Guid ProductId { get; set; }
    
    public Guid ServiceId { get; set; }
}