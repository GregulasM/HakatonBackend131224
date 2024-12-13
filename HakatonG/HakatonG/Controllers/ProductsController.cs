using HakatonG.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HakatonG.Models;


namespace HakatonG.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Products product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("laptops-selection")]
        public async Task<ActionResult<object>> LaptopsSelection()
        {
            var laptops = await _context.Products
                .Where(p => p.Category == "Laptops")
                .Take(3)
                .ToListAsync();

            var mousepad = await _context.Products
                .Where(p => p.Category == "Mousepads")
                .FirstOrDefaultAsync();

            var mouse = await _context.Products
                .Where(p => p.Category == "Mice")
                .FirstOrDefaultAsync();

            return Ok(new
            {
                Laptops = laptops,
                Mousepad = mousepad,
                Mouse = mouse
            });
        }

        [HttpGet("mousepads-selection")]
        public async Task<ActionResult<object>> MousepadsSelection()
        {
            var mousepads = await _context.Products
                .Where(p => p.Category == "Mousepads")
                .Take(3)
                .ToListAsync();

            var softToy = await _context.Products
                .Where(p => p.Category == "Soft Toys")
                .FirstOrDefaultAsync();

            var speaker = await _context.Products
                .Where(p => p.Category == "Speakers")
                .FirstOrDefaultAsync();


            return Ok(new
            {
                Mousepads = mousepads,
                SoftToy = softToy,
                Speaker = speaker
            });
        }

        [HttpGet("mice-selection")]
        public async Task<ActionResult<object>> MiceSelection()
        {
            var mousepads = await _context.Products
                .Where(p => p.Category == "Mice")
                .Take(3)
                .ToListAsync();

            var softToy = await _context.Products
                .Where(p => p.Category == "Laptops")
                .FirstOrDefaultAsync();

            var speaker = await _context.Products
                .Where(p => p.Category == "Speakers")
                .FirstOrDefaultAsync();


            return Ok(new
            {
                Mousepads = mousepads,
                SoftToy = softToy,
                Speaker = speaker
            });
        }


        [HttpGet("soft-toys-selection")]
        public async Task<ActionResult<object>> SoftToysSelection()
        {
            var mousepads = await _context.Products
                .Where(p => p.Category == "Soft Toys")
                .Take(3)
                .ToListAsync();

            var softToy = await _context.Products
                .Where(p => p.Category == "Laptops")
                .FirstOrDefaultAsync();

            var speaker = await _context.Products
                .Where(p => p.Category == "Mousepads")
                .FirstOrDefaultAsync();

            return Ok(new
            {
                Mousepads = mousepads,
                SoftToy = softToy,
                Speaker = speaker
            });
        }

        [HttpGet("speakers-selection")]
        public async Task<ActionResult<object>> SpeakersSelection()
        {
            var mousepads = await _context.Products
                .Where(p => p.Category == "Speakers")
                .Take(3)
                .ToListAsync();

            var softToy = await _context.Products
                .Where(p => p.Category == "Laptops")
                .FirstOrDefaultAsync();

            var speaker = await _context.Products
                .Where(p => p.Category == "Soft Toys")
                .FirstOrDefaultAsync();

            return Ok(new
            {
                Mousepads = mousepads,
                SoftToy = softToy,
                Speaker = speaker
            });
        }


    }
}
