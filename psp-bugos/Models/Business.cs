namespace psp_bugos.Models;

public record Business
{
   public Guid Id { get; set; }

   public string Name { get; set; } = "";
}