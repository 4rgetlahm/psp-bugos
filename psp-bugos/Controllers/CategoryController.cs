using Microsoft.AspNetCore.Mvc;
using psp_bugos.Models;
using psp_bugos.Models.Create;
using psp_bugos.Models.Update;
using psp_bugos.RandomDataGenerator;

namespace psp_bugos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly IRandomDataGenerator _randomDataGenerator;

        public CategoryController(IRandomDataGenerator randomDataGenerator)
        {
            _randomDataGenerator = randomDataGenerator;
        }

        /** <summary>Create a new category</summary>
        * <param name="createCategory">Filled create category model</param>
        * <response code="200">Category is generated and returned</response>
        * <response code="400">Error occured and it's message is returned</response>
        */
        [HttpPost]
        public Category Create(CreateCategory createCategory)
        {
            return _randomDataGenerator.GenerateValues<Category>();
        }

        /** <summary>Update category with new information</summary>
        * <param name="updateCategory">Filled update category model</param>
        * <response code="200">Category is updated and returned</response>
        * <response code="400">Error occured and it's message is returned</response>
        */
        [HttpPatch]
        public Category Update(UpdateCategory updateCategory)
        {
            return _randomDataGenerator.GenerateValues<Category>(updateCategory.CategoryId);
        }

        /** <summary>Delete category</summary>
        * <param name="categoryId" example="e0299fb1-487a-443b-9b34-c6d08493c04d">GUID of category</param>
        * <response code="200">Category is deleted</response>
        * <response code="400">Error occured and it's message is returned</response>
        */
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid categoryId)
        {
            return Ok();
        }
    }
}
