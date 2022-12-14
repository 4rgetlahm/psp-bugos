namespace psp_bugos.Models;

public record Product
{
    public Guid Id { get; set; }
    
    public Guid BusinessId { get; set; }

    public string Name { get; set; } = "";
    
    public decimal Price { get; set; }
    
    public decimal TaxRate { get; set; }
    
    public bool IsEnabled { get; set; }
    
    public string Description { get; set; } = "";

    public string ImageUrl { get; set; } = "";
}