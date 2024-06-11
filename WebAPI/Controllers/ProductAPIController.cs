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
        public IActionResult Get()
        {
            var listProduct = productRepository.GetProducts();
            if (listProduct.Count() > 0)
            {
                return Ok(listProduct);
            }
            else
            {
                return Ok("No data yet");
            }
        }

        // GET api/<ProductAPIController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var checkContainsProduct = productRepository.GetProductById(id);
            if (checkContainsProduct != null)
            {
                return Ok(checkContainsProduct);
            }
            else
            {
                return BadRequest("This product not found");
            }
        }
        #endregion

        // POST api/<ProductAPIController>
        [HttpPost]
        public IActionResult Post(Product product)
        {
            var isInsertSuccess = productRepository.InsertProduct(product);
            if (isInsertSuccess)
            {
                return Ok("Inserted succesfully");
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/<ProductAPIController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Product product)
        {
            var isUpdateSuccess = productRepository.UpdateProduct(product);
            if (isUpdateSuccess)
            {
                return Ok("Updated succesfully");
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<ProductAPIController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var isDeleteSuccess = productRepository.DeleteProduct(id);
            if (isDeleteSuccess)
            {
                return Ok("Deleted succesfully");
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
