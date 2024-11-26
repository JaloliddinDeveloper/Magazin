using Magazin.Brokers.Storages;
using Magazin.Models.Foundations.Products;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTFulSense.Controllers;

namespace Magazin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : RESTFulController
    {
        private readonly IStorageBroker storageBroker;
        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductController(
            IStorageBroker storageBroker,
            IWebHostEnvironment webHostEnvironment)
        {
            this.storageBroker = storageBroker;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct([FromForm] Product Product, IFormFile picture)
        {
            if (picture != null)
            {
                string uploadsFolder = Path.Combine(this.webHostEnvironment.WebRootPath, "images");
                Directory.CreateDirectory(uploadsFolder);

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(picture.FileName);
                string filePath = Path.Combine(uploadsFolder, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await picture.CopyToAsync(fileStream);
                }

                Product.ProductPicture = $"images/{fileName}";
            }

            await this.storageBroker.InsertProductAsync(Product);

            return Created(Product);
        }

        [HttpGet]
        public async ValueTask<ActionResult<IQueryable<Product>>> GetAllProductsAsync()
        {
            try
            {
                IQueryable<Product> products =
                    await this.storageBroker.SelectAllProductsAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await this.storageBroker.SelectProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }
    }
}
