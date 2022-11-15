using Microsoft.AspNetCore.Mvc;
using psp_bugos.Models;
using psp_bugos.Models.ContinuationTokens;
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

        /** <summary>Get all products.</summary>
            * <param name="continuationToken" example="">Token used for pagination(get next top products).</param>
            * <param name="top" example="100">Number of products to be returned in one badge. (maximum - 1000).</param>
            * <response code="200">Returns a all products.</response>
            * <response code="400">Incorrect request: top value larger than 1000 or negative.</response>
            */
        [HttpGet]
        public ActionResult<ContinuationTokenResult<IEnumerable<Product>>> GetAll(string? continuationToken = null,
            [FromQuery] int top = 100)
        {
            if (top > 1000)
                return new BadRequestObjectResult("Top value cannot be greater than 1000");
            if (top < 0)
                return new BadRequestObjectResult("Top value cannot be negative");

            var random = new Random();

            var products = new List<Product>();
            for (int i = 0; i < random.Next(1, 10); i++)
            {
                products.Add(_randomDataGenerator.GenerateValues<Product>());
            }

            return new ContinuationTokenResult<IEnumerable<Product>>
            {
                Response = products,
                ContinuationToken = Guid.NewGuid().ToString()
            };
        }

        /** <summary>Get product by name.</summary>
            * <param name="name" example="banana">Product name.</param>
            * <response code="200">Returned a specific product.</response>
            * <response code="404">No products by the specified name found.</response>
            */ 
        [HttpGet]
        [Route("{name}")]
        public Product Get(string name)
        {
            return _randomDataGenerator.GenerateValues<Product>();
        }

        /** <summary>Get product description.</summary>
            * <param name="id" example="f9299fb1-487a-443b-9b34-c6d08493c04d">Product id.</param>
            * <response code="200">Returned a specific product description.</response>
            * <response code="404">No products by specific id found.</response>
            */ 
        [HttpGet]
        [Route("{id:guid}")]
        public object GetDescription(Guid id)
        {
            var result = _randomDataGenerator.GenerateValues<Product>(id);
            return new {result.Id, result.Description, result.ImageUrl};
        }

        /** <summary>Get products cart.</summary>
            * <param name="ids" >Product ids in the cart.</param>
            * <response code="200">Returned cart data successfully.</response>
            */  
        [HttpPost]
        [Route("cart/")]
        public IEnumerable<Product> GetCart([FromBody] IEnumerable<Guid> ids)
        {
            return ids.Select(id => _randomDataGenerator.GenerateValues<Product>(id));
        }

        /** <summary>Add product to cart.</summary>
            * <param name="id" example="f9299fb1-487a-443b-9b34-c6d08493c04d">Product id.</param>
            * <param name="count" example="10">Product amount to be added.</param>
            * <response code="200">Returned cart data successfully.</response>
            * <response code="400">Incorrect request: count value larger than 1000 or negative.</response>
            * <response code="404">Product not found.</response>
            */  
        [HttpPost]
        [Route("cart/add/{id:guid}")]
        public ActionResult AddProductToCart(Guid id, int count)
        {
            if(count <= 0)
                return new BadRequestObjectResult("Count value cannot be negative or zero");
            
            var orderItem = _randomDataGenerator.GenerateValues<OrderItem>();
            orderItem.Quantity = count;
            orderItem.ProductId = id;
            return Ok(orderItem);
        }

        /** <summary>Update products in a cart.</summary>
            * <param name="id" example="f9299fb1-487a-443b-9b34-c6d08493c04d">Product id.</param>
            * <param name="count" example="10">Product amount to be added.</param>
            * <response code="200">Returned cart data successfully.</response>
            * <response code="400">Incorrect request: count value larger than 1000 or negative.</response>
            * <response code="404">Product not found.</response>
            */  
        [HttpPatch]
        [Route("cart/update/{id:guid}")]
        public ActionResult UpdateServiceInCart(Guid id, int count)
        {
            if(count <=0)
                return new BadRequestObjectResult("Count value cannot be negative or zero");
            
            var orderItem = _randomDataGenerator.GenerateValues<OrderItem>();
            orderItem.Quantity = count;
            orderItem.ProductId = id;
            return Ok(orderItem);
        }

        /** <summary>Remove product in a cart.</summary>
            * <param name="id" example="f9299fb1-487a-443b-9b34-c6d08493c04d">Product id.</param>
            * <response code="200">Returned cart data successfully.</response>
            * <response code="404">Product not found.</response>
            */  
        [HttpDelete]
        [Route("cart/remove/{id:guid}")]
        public ActionResult RemoveServiceFromCart(Guid id)
        {
            return Ok();
        }
    }
}