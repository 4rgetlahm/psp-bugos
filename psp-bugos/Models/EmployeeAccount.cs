namespace psp_bugos.Models;

public record EmployeeAccount : Account
{
    public Privileges Privileges { get; set; }

    public string ZipCode { get; set; } = "";
}