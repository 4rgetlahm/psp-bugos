namespace psp_bugos.Models;

public record CategoryItem
{
    public Guid Id { get; set; }
    
    public Guid CategoryId { get; set; }
    
    public Guid ProductId { get; set; }

    public Guid ServiceId { get; set; }
}