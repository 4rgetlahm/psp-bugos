using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace psp_bugos.Models;

public record CreateShipment
{
    /** <summary>No idea why this field was included in the data model.</summary>
     *  <example>160de46e-b037-45d1-bc57-890c487172a6</example>
     */
    [BindRequired]
    public Guid BusinessId { get; set; }

    /** <summary>Recipient name (a customer might order something for someone else).</summary>
     *  <example>Micius</example>
     */
    [BindRequired]
    public string Recipient { get; set; } = "";

    /** <summary>Phone number.</summary>
     *  <example>+37070070007</example>
     */
    [BindRequired]
    public string PhoneNo { get; set; } = "";

    /** <summary>Required address line.</summary>
     *  <example>Didlaukio g. 47</example>
     */
    [BindRequired]
    public string AddressLine1 { get; set; } = "";

    /** <summary>Optional address line.</summary>
     */
    public string AddressLine2 { get; set; } = "";

    /** <summary>City.</summary>
     *  <example>Vilnius</example>
     */
    [BindRequired]
    public string City { get; set; } = "";

    /** <summary>Postal (ZIP) code.</summary>
     *  <example>LT-08303</example>
     */
    [BindRequired]
    public string ZipCode { get; set; } = "";
}