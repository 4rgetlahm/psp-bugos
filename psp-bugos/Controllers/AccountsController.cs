using Microsoft.AspNetCore.Mvc;
using psp_bugos.Models;
using psp_bugos.RandomDataGenerator;

namespace psp_bugos.Controllers;

[ApiController]
public class AccountsController : Controller
{
    private readonly IRandomDataGenerator _randomDataGenerator;

    public AccountsController(IRandomDataGenerator randomDataGenerator)
    {
        _randomDataGenerator = randomDataGenerator;
    } 
    [HttpGet]
    [Route("employees")]
    public IEnumerable<EmployeeAccount> GetAllEmployees([FromQuery] int top = 100)
    {
        var employees = new List<EmployeeAccount>();
        for (int i = 0; i < top; i++)
        {
            employees.Add(_randomDataGenerator.GenerateValues<EmployeeAccount>());
        }

        return employees;
    }
    
    [HttpGet("employees/{id}")]
    public EmployeeAccount GetEmployeeAccount(Guid id)
    {
        return _randomDataGenerator.GenerateValues<EmployeeAccount>();
    }

    [HttpGet("customers/{id}")]
    public CustomerAccount GetCustomerAccount(Guid id)
    {
        return _randomDataGenerator.GenerateValues<CustomerAccount>();
    }
    
}