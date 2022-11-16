using Microsoft.AspNetCore.Mvc;
using psp_bugos.Models.Update;

namespace psp_bugos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountManagementController : Controller
    {
        /** <summary>Update employee account privileges</summary>
         * <param name="employeePrivilegeUpdateRequest">Filled model with employee privilege change information</param>
         * <response code="200">If no issues occured and privileges changed</response>
         * <response code="400">Returns what error occured</response>
         */
        [HttpPut]
        [Route("employee/privileges/edit")]
        public async Task<IActionResult> EditEmployeePrivileges(UpdateEmployeePrivileges employeePrivilegeUpdateRequest)
        {
            return Ok();
        }
    }
}
