using Microsoft.AspNetCore.Mvc;
using ObjectBusiness;
using Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        #region Variable
        private readonly IProductRepository productRepository;
        #endregion

        #region Constructor
        public ProductAPIController()
        {
            productRepository = new ProductRepository();
        }
        #endregion

        #region GET
        // GET: api/<ProductAPIController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var listProduct = productRepository.GetProducts();
            return listProduct;
        }

        // GET api/<ProductAPIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        #endregion

        // POST api/<ProductAPIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
