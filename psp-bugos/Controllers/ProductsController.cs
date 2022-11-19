using Microsoft.AspNetCore.Mvc;
using psp_bugos.Models;
using psp_bugos.Models.ContinuationTokens;
using psp_bugos.RandomDataGenerator;
using psp_bugos.Utilities;
using System.ComponentModel.DataAnnotations;

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
        [Route("find/name/{name}")]
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
        [Route("{id:guid}/description")]
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

        /** <summary>Get products by category.</summary>
            * <param name="category" example="Fruits">Product category.</param>
            * <param name="continuationToken" example="">Token used for pagination(get next top products).</param>
            * <param name="top" example="100">Number of products to be returned in one badge. (maximum - 1000).</param>
            * <response code="200">Returns products.</response>
            * <response code="400">Incorrect request: top value larger than 1000 or negative.</response>
            */
        [HttpGet]
        [Route("find/category/{category}")]
        public ActionResult<ContinuationTokenResult<IEnumerable<Product>>> GetByCategory(string category, string? continuationToken = null,
            int top = 100)
        {
            if (top > 1000)
                return new BadRequestObjectResult("Top value cannot be greater than 1000");
            if (top < 0)
                return new BadRequestObjectResult("Top value cannot be negative");

            var products = new List<Product>();
            for (int i = 0; i < top; i++)
            {
                products.Add(_randomDataGenerator.GenerateValues<Product>());
            }

            return new ContinuationTokenResult<IEnumerable<Product>>
            {
                Response = products,
                ContinuationToken = Guid.NewGuid().ToString()
            };
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
            if (count <= 0)
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
        public ActionResult UpdateProductInCart(Guid id, int count)
        {
            if (count <= 0)
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
        public ActionResult RemoveProductFromCart(Guid id)
        {
            return Ok();
        }

        /** <summary>Remove product in a cart.</summary>
            * <param name="id" example="f9299fb1-487a-443b-9b34-c6d08493c04d">Product id.</param>
            * <param name="businessLocationId" example="f9299fb1-487a-443b-9b34-c6d08493c04d">BusinessLocation, where product is stored, id.</param>
            * <response code="200">Returns a modified inventory.</response>
            */
        [HttpPatch]
        [Route("{id}/inventoryLocation/{businessLocationId}")]
        public ActionResult UpdateInventory(Guid id, Guid businessLocationId, int? supply)
        {
            var inventory = _randomDataGenerator.GenerateValues<Inventory>(id);
            inventory.BusinessLocationId = businessLocationId;
            inventory.Supply = supply ?? inventory.Supply;
            return Ok(inventory);
        }

        /** <summary>Create a new product.</summary>
         * <response code="200">Returns a newly created product.</response>
         */
        [HttpPost]
        public ActionResult CreateProduct([FromQuery] CreateProduct createProduct)
        {
            var product = _randomDataGenerator.GenerateValues<Product>();
            product = DtoMapper.MapDtoOnDto(createProduct, product);
            product.ImageUrl = string.IsNullOrEmpty(createProduct.ImageUrl)
                ? ""
                : createProduct.ImageUrl;

            return Ok(product);
        }

        /** <summary>Get an existing product.</summary>
         * <param name="id" example="f9299fb1-487a-443b-9b34-c6d08493c04d">Product id.</param>
         * <response code="200">Returns an appropriate product.</response>
         */
        [HttpGet]
        [Route("{id}")]
        public ActionResult GetProduct(Guid id)
        {
            var product = _randomDataGenerator.GenerateValues<Product>(id);
            return Ok(product);
        }

        /** <summary>Update (edit) an existing product.</summary>
         * <response code="200">Returns a modified product.</response>
         */
        [HttpPatch]
        public ActionResult UpdateProduct([FromQuery] UpdateProduct updateProduct)
        {
            var product = _randomDataGenerator.GenerateValues<Product>();
            product = DtoMapper.MapDtoOnDto(updateProduct, product);
            return Ok(product);
        }

        /** <summary>Add an existing category to the product.</summary>
         * <param name="id" example="f9299fb1-487a-443b-9b34-c6d08493c04d">Product id.</param>
         * <param name="categoryId" example="aa4a7a53-5e8e-40f7-9e29-4a220bf03f60">Id of an existing category that was created via categories endpoint.</param>
         * <response code="200">Returns a categoryItem.</response>
         */
        [HttpPost]
        [Route("{id}/categories")]
        public ActionResult AddProductCategory(Guid id, [Required] Guid categoryId)
        {
            var categoryItem = _randomDataGenerator.GenerateValues<CategoryItem>();
            categoryItem.ProductId = id;
            categoryItem.CategoryId = categoryId;
            categoryItem.ServiceId = null;

            return Ok(categoryItem);
        }

        /** <summary>Delete an existing category from the product.</summary>
         * <param name="id" example="f9299fb1-487a-443b-9b34-c6d08493c04d">Product id.</param>
         * <param name="categoryItemId" example="aa4a7a53-5e8e-40f7-9e29-4a220bf03f60">Id of a category item (an id of an object received from POST products/id/categories endpoint).</param>
         * <response code="200"></response>
         */
        [HttpDelete]
        [Route("{id}/categories/{categoryItemId}")]
        public ActionResult RemoveProductCategory(Guid id, Guid categoryItemId)
        {
            return Ok();
        }

        /** <summary>Add an existing discount to the product.</summary>
         * <param name="id" example="f9299fb1-487a-443b-9b34-c6d08493c04d">Product id.</param>
         * <param name="discountId" example="aa4a7a53-5e8e-40f7-9e29-4a220bf03f60">Id of an existing discount that was created via discounts endpoint.</param>
         * <response code="200">Returns a discountItem.</response>
         */
        [HttpPost]
        [Route("{id}/discounts")]
        public ActionResult AddProductDiscount(Guid id, [Required] Guid discountId)
        {
            var discountItem = _randomDataGenerator.GenerateValues<DiscountItem>();
            discountItem.ProductId = id;
            discountItem.DiscountId = discountId;
            discountItem.ServiceId = null;

            return Ok(discountItem);
        }

        /** <summary>Delete an existing discount from the product.</summary>
         * <param name="id" example="f9299fb1-487a-443b-9b34-c6d08493c04d">Product id.</param>
         * <param name="discountItemId" example="aa4a7a53-5e8e-40f7-9e29-4a220bf03f60">Id of a discount item (an id of an object received from POST products/id/discounts endpoint).</param>
         * <response code="200"></response>
         */
        [HttpDelete]
        [Route("{id}/discounts/{discountItemId}")]
        public ActionResult RemoveProductDiscount(Guid id, Guid discountItemId)
        {
            return Ok();
        }
    }
}
