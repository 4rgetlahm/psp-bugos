namespace psp_bugos.Models;

public record Category
{
    public Guid Id { get; set; }
    
    public Guid BusinessId { get; set; }

    public string Name { get; set; } = "";
    
    public Guid ParentCategoryId { get; set; }
}