using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Superstore.Context;
using Superstore.Models;

namespace Superstore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly SuperstoreContext _context;

        public ProductsController(SuperstoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            IEnumerable<Product> products = _context.Products.AsNoTracking().ToList();

            if (products is null)
            {
                return NotFound("Products not found...");
            }

            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "GetProductById")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = _context.Products.AsNoTracking().FirstOrDefault(p => p.ProductId == id);

            if (product is null)
            {
                return NotFound("Product not found...");
            }

            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {
            if (product is null)
                return BadRequest();

            _context.Products.Add(product);
            _context.SaveChanges();

            return new CreatedAtRouteResult("GetProductById",
                new { productId = product.ProductId, product });
        }

        [HttpPut("{id:int}")]
        public ActionResult<Product> UpdateProduct(int id, Product product)
        {
            if (id != product.ProductId)
                BadRequest();

            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(product);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<Product> DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);

            if (product is null)
                return NotFound("Product not found...");

            _context.Products.Remove(product);
            _context.SaveChanges();

            return Ok(product);
        }
    }
}
