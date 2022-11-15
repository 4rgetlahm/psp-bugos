using Microsoft.AspNetCore.Mvc;
using psp_bugos.Models;
using psp_bugos.Models.ContinuationTokens;
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
    
    /** <summary>Get all empployees.</summary>
      * <param name="continuationToken" example="">Token used for pagination(get next top employees)</param>
      * <param name="top" example="100">Number of employees to be returned in one badge. (maximum - 1000)</param>
      * <response code="200">Returns a created business location.</response>
      * <response code="400">Incorrect request: top value larger than 1000 or negative.</response>
      */ 
    [HttpGet]
    [Route("employees")]
    public ActionResult<ContinuationTokenResult<IEnumerable<EmployeeAccount>>> GetAllEmployees(string? continuationToken = null, [FromQuery] int top = 100)
    {
        if (top > 1000)
            return new BadRequestObjectResult("Top value cannot be greater than 1000");
        if(top < 0)
            return new BadRequestObjectResult("Top value cannot be negative");
        
        var employees = new List<EmployeeAccount>();
        for (int i = 0; i < top; i++)
        {
            employees.Add(_randomDataGenerator.GenerateValues<EmployeeAccount>());
        }

        return new ContinuationTokenResult<IEnumerable<EmployeeAccount>>
        {
            Response = employees,
            ContinuationToken = Guid.NewGuid().ToString()
        };
    }
    
    /** <summary>Get empployee.</summary>
      * <param name="id" example="e0299fb1-487a-443b-9b34-c6d08493c04d">Employee id</param>
      * <response code="200">Returns employee account data.</response>
      * <response code="404">Employee not found(implement in 3rd task).</response>
      */  
    [HttpGet("employees/{id}")]
    public ActionResult<EmployeeAccount> GetEmployeeAccount(Guid id)
    {
        return _randomDataGenerator.GenerateValues<EmployeeAccount>();
    }

    /** <summary>Get customer.</summary>
      * <param name="id" example="e0299fb1-487a-443b-9b34-c6d08493c04d">Customer id</param>
      * <response code="200">Returns customer account data.</response>
      * <response code="404">Customer not found(implement in 3rd task).</response>
      */   
    [HttpGet("customers/{id}")]
    public ActionResult<CustomerAccount> GetCustomerAccount(Guid id)
    {
        return _randomDataGenerator.GenerateValues<CustomerAccount>();
    }
    
}