using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RpgItems.Api.Data;
using RpgItems.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace RpgItems.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly AppDbContext _db;
        public ItemsController(AppDbContext db) => _db = db;

        public class ItemCreateDto
        {
            [Required, StringLength(50)]
            public string Name { get; set; } = string.Empty;

            [Required]
            public Rarity Rarity { get; set; }

            [Range(0.01, 9999.99)]
            public decimal Price { get; set; }
        }

        public class ItemUpdateDto
        {
            [Required, StringLength(50)]
            public string Name { get; set; } = string.Empty;

            [Required]
            public Rarity Rarity { get; set; }

            [Range(0.01, 9999.99)]
            public decimal Price { get; set; }
        }

        // GET /api/items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetAll()
            => Ok(await _db.Items.AsNoTracking().ToListAsync());

        // GET /api/items/{id}
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Item>> GetById(int id)
        {
            var item = await _db.Items.FindAsync(id);
            return item is null ? NotFound() : Ok(item);
        }

        // POST /api/items
        [HttpPost]
        public async Task<ActionResult<Item>> Create([FromBody] ItemCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = new Item { Name = dto.Name, Rarity = dto.Rarity, Price = dto.Price };
            _db.Items.Add(entity);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
        }

        // PUT /api/items/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] ItemUpdateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var entity = await _db.Items.FindAsync(id);
            if (entity is null) return NotFound();

            entity.Name = dto.Name;
            entity.Rarity = dto.Rarity;
            entity.Price = dto.Price;

            await _db.SaveChangesAsync();
            return NoContent();
        }

        // DELETE /api/items/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _db.Items.FindAsync(id);
            if (entity is null) return NotFound();

            _db.Items.Remove(entity);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
