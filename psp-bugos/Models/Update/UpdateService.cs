namespace psp_bugos.Models.Update;

public record UpdateService
{
    /** <summary>Name of the service.</summary>
     *  <example>Thai masssage</example>
     */
    public string Name { get; set; } = "";

    /** <summary>Price of the service.</summary>
     *  <example>45.55</example>
     */
    public decimal Price { get; set; }


    /** <summary>Tax rate (in percent).</summary>
     *  <example>21.00</example>
     */
    public decimal TaxRate { get; set; }

    /** <summary>Duration of the service (hh:mm:ss).</summary>
     *  <example>00:15:00</example>
     */
    public TimeSpan Duration { get; set; }

    /** <summary>Availability of the service.</summary>
     *  <example>true</example>
     */
    public bool IsEnabled { get; set; }

    /** <summary>Description of a service.</summary>
     *  <example>Thai massage is a traditional therapy combining acupressure.</example>
     */
    public string Description { get; set; } = "";

    /** <summary>URL to the picture.</summary>
     *  <example>https://en.wikipedia.org/wiki/Thai_massage#/media/File:Thaimassage.jpg</example>
     */
    public string ImageUrl { get; set; } = "";
}