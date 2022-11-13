namespace psp_bugos.Models;

public record Inventory
{
    public Guid ItemId { get; set; }

    public Guid BusinessLocationId { get; set; }
}