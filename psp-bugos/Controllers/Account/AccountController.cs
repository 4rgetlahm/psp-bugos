using Microsoft.AspNetCore.Mvc;
using psp_bugos.RandomDataGenerator;
using System.Text;
using System.Text.Json;

namespace psp_bugos.Controllers.Account
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IRandomDataGenerator _randomDataGenerator;

        public AccountController(IRandomDataGenerator randomDataGenerator)
        {
            _randomDataGenerator = randomDataGenerator;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(dynamic accountCreateRequest)
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
                new { 
                    accessToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(header))).TrimEnd('=') 
                    + "." 
                    + Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(payload))).TrimEnd('=')
                }
            );
        }

        [HttpPost]
        [Route("verify/create")]
        public async Task<IActionResult> VerifyCreation(dynamic accountVerifyRequest)
        {
            return Ok();
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(dynamic accountUpdateRequest)
        {
            return Ok();
        }

        [HttpPost]
        [Route("verify/update")]
        public async Task<IActionResult> VerifyUpdate(dynamic accountVerifyUpdateRequest)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(dynamic accountUpdateRequest)
        {
            return Ok();
        }

        [HttpPost]
        [Route("verify/delete")]
        public async Task<IActionResult> VerifyDelete(dynamic accountVerifyUpdateRequest)
        {
            return Ok();
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(dynamic loginRequest)
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

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout(dynamic logoutRequest)
        {
            return Ok();
        }
    }
}
