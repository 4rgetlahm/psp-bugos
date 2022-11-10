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
        [Route("[controller]/{id:guid}")]
        public Product Get(Guid id)
        {
            return m_randomDataGenerator.GenerateValues<Product>();
        }
    }
}