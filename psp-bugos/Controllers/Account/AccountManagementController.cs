using Microsoft.AspNetCore.Mvc;

namespace psp_bugos.Controllers.Account
{
    [ApiController]
    [Route("[controller]")]
    public class AccountManagementController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> EditEmployeePrivileges(dynamic employeePrivilegesEditRequest)
        {
            return Ok();
        }
    }
}
