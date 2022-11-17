using Microsoft.AspNetCore.Mvc;
using psp_bugos.Models;
using psp_bugos.Models.Create;
using psp_bugos.Models.Update;
using psp_bugos.RandomDataGenerator;

namespace psp_bugos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiscountController : Controller
    {
        private readonly IRandomDataGenerator _randomDataGenerator;
        public DiscountController(IRandomDataGenerator randomDataGenerator)
        {
            _randomDataGenerator = randomDataGenerator;
        }

        /** <summary>Create a new Discount</summary>
        * <param name="createDiscount">Filled create Discount model</param>
        * <response code="200">Discount is generated and returned</response>
        * <response code="400">Error occured and it's message is returned</response>
        */
        [HttpPost]
        public Discount Create(CreateDiscount createDiscount)
        {
            return _randomDataGenerator.GenerateValues<Discount>();
        }

        /** <summary>Update Discount with new information</summary>
        * <param name="updateDiscount">Filled update Discount model</param>
        * <response code="200">Discount is updated and returned</response>
        * <response code="400">Error occured and it's message is returned</response>
        */
        [HttpPatch]
        public Discount Update(UpdateDiscount updateDiscount)
        {
            return _randomDataGenerator.GenerateValues<Discount>(updateDiscount.DiscountId);
        }

        /** <summary>Delete Discount</summary>
        * <param name="DiscountId" example="e0299fb1-487a-443b-9b34-c6d08493c04d">GUID of Discount</param>
        * <response code="200">Discount is deleted</response>
        * <response code="400">Error occured and it's message is returned</response>
        */
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid DiscountId)
        {
            return Ok();
        }
    }
}
