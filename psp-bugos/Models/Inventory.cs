namespace psp_bugos.Models;

public record Inventory
{
    public Guid ProductId { get; set; }

    public Guid BusinessLocationId { get; set; }

    public int Supply { get; set; }
}