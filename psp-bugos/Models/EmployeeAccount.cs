namespace psp_bugos.Models;

public class EmployeeAccount : Account
{
    public Privileges Privileges { get; set; }

    public string ZipCode { get; set; } = "";
}