namespace psp_bugos.Models;

public class Discount
{
    public Guid Id { get; set; }

    public string Name { get; set; } = "";
    
    public Guid BusinessId { get; set; }

    public int Rate { get; set; }
}