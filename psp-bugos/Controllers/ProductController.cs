using Microsoft.AspNetCore.Mvc;
using psp_bugos.Models;
using psp_bugos.RandomDataGenerator;

namespace psp_bugos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IRandomDataGenerator m_randomDataGenerator;

        public ProductController(IRandomDataGenerator randomDataGenerator)
        {
            m_randomDataGenerator = randomDataGenerator;
        }

        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            var random = new Random();

            var products = new List<Product>();
            for (int i = 0; i < random.Next(1, 10); i++)
            {
                products.Add(m_randomDataGenerator.GenerateValues<Product>());
            }

            return products;
        }

        [HttpGet]
        [Route("{name}")]
        public Product Get(string name)
        {
            return m_randomDataGenerator.GenerateValues<Product>();
        }

        [HttpGet]
        [Route("{id:guid}")]
        public object GetDescription(Guid id)
        {
            Product result = m_randomDataGenerator.GenerateValues<Product>(id);
            return new {result.Id, result.Description, result.ImageUrl};
        }

        [HttpPost]
        [Route("cart/")]
        public IEnumerable<Product> GetCart([FromBody] IEnumerable<Guid> ids)
        {
            return ids.Select(id => m_randomDataGenerator.GenerateValues<Product>(id));
        }

        [HttpPost]
        [Route("cart/add/{id:guid}")]
        public ActionResult AddProductToCart(Guid id, int count)
        {
            return Ok();
        }

        [HttpPatch]
        [Route("cart/update/{id:guid}")]
        public ActionResult UpdateServiceInCart(Guid id, int count)
        {
            return Ok();
        }

        [HttpDelete]
        [Route("cart/remove/{id:guid}")]
        public ActionResult RemoveServiceFromCart(Guid id)
        {
            return Ok();
        }
    }
}