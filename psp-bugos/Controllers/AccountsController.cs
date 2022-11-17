using Microsoft.AspNetCore.Mvc;
using psp_bugos.Models;
using psp_bugos.Models.Authentication;
using psp_bugos.Models.ContinuationTokens;
using psp_bugos.Models.Create;
using psp_bugos.Models.Update;
using psp_bugos.Models.Verifications;
using psp_bugos.RandomDataGenerator;
using System.Text;
using System.Text.Json;

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

    /** <summary>Create an account</summary>
     * <param name="accountCreateRequest">Filled model with required account information</param>
     * <response code="200">Returns JWT access token</response>
     * <response code="400">Returns what error occured</response>
     */
    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create(CreateAccount accountCreateRequest)
    {
        Random random = new Random();
        var header = new { typ = "JWT", alg = "none" };
        var payload = new
        {
            ver = 1,
            iss = "https://system.com",
            aud = "https://system.com",
            sub = Guid.NewGuid(),
            iat = random.Next(1666268000, 1666368000),
            exp = random.Next(1666368000, 1766268000)
        };

        return Ok(
            new
            {
                accessToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(header))).TrimEnd('=')
                + "."
                + Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(payload))).TrimEnd('=')
            }
        );
    }

    /** <summary>Verify (complete) account creation</summary>
     * <param name="accountVerifyRequest">Filled model with required verification information</param>
     * <response code="200">If verification completed successfully</response>
     * <response code="400">Returns what error occured</response>
     */
    [HttpPost]
    [Route("verify/create")]
    public async Task<IActionResult> VerifyCreation(Verification accountVerifyRequest)
    {
        return Ok();
    }

    /** <summary>Request an update to account with new information</summary>
     * <param name="accountUpdateRequest">Filled model with new account information</param>
     * <response code="200">If request completed successfully</response>
     * <response code="400">Returns what error occured</response>
     */
    [HttpPatch]
    [Route("update")]
    public async Task<IActionResult> Update(UpdateAccount accountUpdateRequest)
    {
        return Ok();
    }

    /** <summary>Verify (complete) account update</summary>
     * <param name="accountVerifyUpdateRequest">Filled model with required verification information</param>
     * <response code="200">If verification completed successfully</response>
     * <response code="400">Returns what error occured</response>
     */
    [HttpPost]
    [Route("verify/update")]
    public async Task<IActionResult> VerifyUpdate(Verification accountVerifyUpdateRequest)
    {
        return Ok();
    }

    /** <summary>Request an account deletion</summary>
     * <param name="accountId">GUID of an account</param>
     * <response code="200">If deletion request was created successfully</response>
     * <response code="400">Returns what error occured</response>
     */
    [HttpDelete]
    [Route("delete")]
    public async Task<IActionResult> Delete(Guid accountId)
    {
        return Ok();
    }

    /** <summary>Verify (complete) account deletion</summary>
     * <param name="accountVerifyDeleteRequest">Filled model with required verification information</param>
     * <response code="200">If verification completed successfully</response>
     * <response code="400">Returns what error occured</response>
     */
    [HttpPost]
    [Route("verify/delete")]
    public async Task<IActionResult> VerifyDelete(Verification accountVerifyDeleteRequest)
    {
        return Ok();
    }

    /** <summary>Login to an account</summary>
     * <param name="loginRequest">Filled model with account login information</param>
     * <response code="200">Returns JWT access token</response>
     * <response code="400">Returns what error occured</response>
     */
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        Random random = new Random();
        var header = new { typ = "JWT", alg = "none" };
        var payload = new
        {
            ver = 1,
            iss = "https://system.com",
            aud = "https://system.com",
            sub = Guid.NewGuid(),
            iat = random.Next(1666268000, 1666368000),
            exp = random.Next(1666368000, 1766268000)
        };

        return Ok(
            new
            {
                accessToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(header))).TrimEnd('=')
                + "."
                + Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(payload))).TrimEnd('=')
            }
        );
    }

    /** <summary>Revoke JWT access token</summary>
     * <param name="logoutRequest">Filled model with logout request information</param>
     * <response code="200">If revoking was successful</response>
     * <response code="400">Returns what error occured</response>
     */
    [HttpPost]
    [Route("logout")]
    public async Task<IActionResult> Logout(LogoutRequest logoutRequest)
    {
        return Ok();
    }

}