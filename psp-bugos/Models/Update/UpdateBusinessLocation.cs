namespace psp_bugos.Models.Update;

public record UpdateBussinessLocation
{
    /** <summary>GUID of a bussiness.</summary>
     *  <example>2e816ad7-5cd7-4da0-bc93-879b36633207</example>
     */
    public Guid BusinessId { get; set; }

    /** <summary>Name of a bussiness location.</summary>
     *  <example>antiCaffeine</example>
     */
    public string Name { get; set; } = "";

    /** <summary>Street name (with street number).</summary>
     *  <example>24 Evergreen Street</example>
     */
    public string Street { get; set; } = "";

    /** <summary>City name.</summary>
     *  <example>Cork</example>
     */
    public string City { get; set; } = "";

    /** <summary>Postal (ZIP) code.</summary>
     *  <example>T12 WP70</example>
     */
    public string ZipCode { get; set; } = "";

    /** <summary>Genral phone number of that bussiness location.</summary>
     *  <example>+37070070007</example>
     */
    public string PhoneNumber { get; set; } = "";
}