using Microsoft.AspNetCore.Mvc;
using ObjectBusiness;
using Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryAPIController : ControllerBase
    {
        #region Variable
        private readonly IProductCategoryRepository categoryRepository;
        #endregion

        #region Constructor
        public ProductCategoryAPIController()
        {
            categoryRepository = new ProductCategoryRepository();
        }
        #endregion

        #region GET
        // GET: api/<ProductCategoryAPIController>
        [HttpGet]
        public IActionResult Get()
        {
            var listCategories = categoryRepository.GetProductCategories();
            if (listCategories.Count() > 0)
            {
                return Ok(listCategories);
            }
            else
            {
                return Ok("No data yet");
            }
        }

        // GET api/<ProductCategoryAPIController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = categoryRepository.GetCategoryById(id);
            if (category == null)
            {
                return BadRequest("This category not found");
            }
            else
            {
                return Ok(category);
            }
        }
        #endregion

        // POST api/<ProductCategoryAPIController>
        [HttpPost]
        public void Post(ProductCategory category)
        {
            categoryRepository.InsertCategory(category);
        }

        // PUT api/<ProductCategoryAPIController>/5
        [HttpPut("{id}")]
        public void Put(ProductCategory category)
        {
            categoryRepository.UpdateCategory(category);
        }

        // DELETE api/<ProductCategoryAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            categoryRepository.DeleteCategory(id);
        }
    }
}
