using Microsoft.AspNetCore.Mvc;

namespace psp_bugos.Controllers.Account
{
    [ApiController]
    [Route("[controller]")]
    public class AccountManagementController : Controller
    {
        [HttpPut]
        [Route("employee/privileges/edit")]
        public async Task<IActionResult> EditEmployeePrivileges(dynamic employeePrivilegesEditRequest)
        {
            return Ok();
        }
    }
}
