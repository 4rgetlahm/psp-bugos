using Microsoft.AspNetCore.Mvc;
using psp_bugos.Models;
using psp_bugos.RandomDataGenerator;

namespace psp_bugos.Controllers;

[ApiController]
public class AccountController : Controller
{
    private readonly IRandomDataGenerator m_randomDataGenerator;

    public AccountController(IRandomDataGenerator randomDataGenerator)
    {
        m_randomDataGenerator = randomDataGenerator;
    } 
    [HttpGet]
    [Route("employees")]
    public IEnumerable<EmployeeAccount> GetAllEmployees([FromQuery] int top = 100)
    {
        var employees = new List<EmployeeAccount>();
        for (int i = 0; i < top; i++)
        {
            employees.Add(m_randomDataGenerator.GenerateValues<EmployeeAccount>());
        }

        return employees;
    }
    
    [HttpGet("employees/{id}")]
    public EmployeeAccount GetEmployeeAccount(int id)
    {
        return m_randomDataGenerator.GenerateValues<EmployeeAccount>();
    }
    
    [HttpGet("customers/{id}")]
    public CustomerAccount GetCustomerAccount(int id)
    {
        return m_randomDataGenerator.GenerateValues<CustomerAccount>();
    }
    
}