using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Superstore.Context;
using Superstore.Models;

namespace Superstore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly SuperstoreContext _context;

        public CategoriesController(SuperstoreContext context)
        {
            _context = context;
        }

        [HttpGet("products")]
        public ActionResult<IEnumerable<Category>> GetAllCategoriesProducts()
        {
            return _context.Categories.AsNoTracking().Include(p => p.Products.Take(10)).ToList();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            IEnumerable<Category> categories = _context.Categories.AsNoTracking().ToList();

            if (categories is null)
            {
                return NotFound("Category not found...");
            }

            return Ok(categories);
        }

        [HttpGet("{id:int}", Name = "GetCategoryById")]
        public ActionResult<Category> GetCategoryById(int id)
        {
            var category = _context.Categories.AsNoTracking().FirstOrDefault(p => p.CategoryId == id);

            if (category is null)
            {
                return NotFound("Category not found...");
            }

            return Ok(category);
        }

        [HttpPost]
        public ActionResult<Category> CreateCategory(Category category)
        {
            if (category is null)
                return BadRequest();

            _context.Categories.Add(category);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetCategoryId",
                new { productId = category.CategoryId, category });
        }

        [HttpPut("{id:int}")]
        public ActionResult<Category> UpdateCategory(int id, Category category)
        {
            if (id != category.CategoryId)
                BadRequest();

            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(category);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Category> DeleteCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(p => p.CategoryId == id);

            if (category is null)
                return NotFound("Category not found...");

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return Ok(category);
        }
    }
}
