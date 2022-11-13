using Microsoft.AspNetCore.Mvc;
using psp_bugos.Models;
using psp_bugos.RandomDataGenerator;

namespace psp_bugos.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController : Controller
    {
        private readonly IRandomDataGenerator _randomDataGenerator;

        public ProductsController(IRandomDataGenerator randomDataGenerator)
        {
            _randomDataGenerator = randomDataGenerator;
        }

        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            var random = new Random();

            var products = new List<Product>();
            for (int i = 0; i < random.Next(1, 10); i++)
            {
                products.Add(_randomDataGenerator.GenerateValues<Product>());
            }

            return products;
        }

        [HttpGet]
        [Route("{name}")]
        public Product Get(string name)
        {
            return _randomDataGenerator.GenerateValues<Product>();
        }

        [HttpGet]
        [Route("{id:guid}")]
        public object GetDescription(Guid id)
        {
            var result = _randomDataGenerator.GenerateValues<Product>(id);
            return new {result.Id, result.Description, result.ImageUrl};
        }

        [HttpPost]
        [Route("cart/")]
        public IEnumerable<Product> GetCart([FromBody] IEnumerable<Guid> ids)
        {
            return ids.Select(id => _randomDataGenerator.GenerateValues<Product>(id));
        }

        [HttpPost]
        [Route("cart/add/{id:guid}")]
        public ActionResult AddProductToCart(Guid id, int count)
        {
            var orderItem = _randomDataGenerator.GenerateValues<OrderItem>();
            orderItem.Quantity = count;
            orderItem.ProductId = id;
            return Ok(orderItem);
        }

        [HttpPatch]
        [Route("cart/update/{id:guid}")]
        public ActionResult UpdateServiceInCart(Guid id, int count)
        {
            var orderItem = _randomDataGenerator.GenerateValues<OrderItem>();
            orderItem.Quantity = count;
            orderItem.ProductId = id;
            return Ok(orderItem);
        }

        [HttpDelete]
        [Route("cart/remove/{id:guid}")]
        public ActionResult RemoveServiceFromCart(Guid id)
        {
            return Ok();
        }
    }
}