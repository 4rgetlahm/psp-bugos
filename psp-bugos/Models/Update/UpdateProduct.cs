namespace psp_bugos.Models;

public record UpdateProduct
{
    /** <summary>No idea why this field was included in the data model.</summary>
     *  <example>160de46e-b037-45d1-bc57-890c487172a6</example>
     */
    public Guid BusinessId { get; set; }

    /** <summary>Name of the product.</summary>
     *  <example>Anger management toy</example>
     */
    public string Name { get; set; } = "";

    /** <summary>Price.</summary>
     *  <example>120.00</example>
     */
    public decimal Price { get; set; }

    /** <summary>Tax rate (in percent).</summary>
     *  <example>21.00</example>
     */
    public decimal TaxRate { get; set; }

    /** <summary>Availability of the product.</summary>
     *  <example>true</example>
     */
    public bool IsEnabled { get; set; }

    /** <summary>Description of a product.</summary>
     *  <example>Makes you feel better.</example>
     */
    public string Description { get; set; } = "";

    public string ImageUrl { get; set; } = "";
}