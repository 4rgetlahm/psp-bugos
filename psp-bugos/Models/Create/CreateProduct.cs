using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace psp_bugos.Models;

public record CreateProduct
{
    /** <summary>No idea why this field was included in the data model.</summary>
     *  <example>160de46e-b037-45d1-bc57-890c487172a6</example>
     */
    [BindRequired]
    public Guid BusinessId { get; set; }

    /** <summary>Name of the product.</summary>
     *  <example>Anger management toy</example>
     */
    [BindRequired]
    public string Name { get; set; } = "";

    /** <summary>Price.</summary>
     *  <example>120.00</example>
     */
    [BindRequired]
    public decimal Price { get; set; }

    /** <summary>Tax rate (in percent).</summary>
     *  <example>21.00</example>
     */
    [BindRequired]
    public decimal TaxRate { get; set; }

    /** <summary>Availability of the product.</summary>
     *  <example>true</example>
     */
    [BindRequired]
    public bool IsEnabled { get; set; }

    /** <summary>Description of a product.</summary>
     *  <example>Makes you feel better.</example>
     */
    [BindRequired]
    public string Description { get; set; } = "";

    /** <summary>URL to the product's picture.</summary>
     *  <example>https://upload.wikimedia.org/wikipedia/commons/thumb/4/4e/Wooden_toys_%28cropped%29.JPG/1280px-Wooden_toys_%28cropped%29.JPG</example>
     */
    public string ImageUrl { get; set; } = "";
}