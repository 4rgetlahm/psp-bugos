namespace psp_bugos.Models;

public class Account
{
    public Guid Id { get; set; }

    public Guid BusinessId { get; set; }

    public string Username { get; set; } = "";

    public string Password { get; set; } = "";

    public string Name { get; set; } = "";

    public string SurName { get; set; } = "";

    public string PhoneNumber { get; set; } = "";

    public string Email { get; set; } = "";

    public string AddressLine1 { get; set; } = "";

    public string AddressLine2 { get; set; } = "";

    public string City { get; set; } = "";
}