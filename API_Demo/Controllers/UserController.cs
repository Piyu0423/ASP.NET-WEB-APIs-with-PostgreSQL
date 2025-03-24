using API_Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UsersController(AppDbContext context) {
            _context = context;
        }
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var results = await _context.Users.Select(x => new User
            {
                Id = x.Id,
                Name = x.Name,
                Occupation = x.Occupation,
                Salary = x.Salary,
            }).ToListAsync();
            return Ok(results);
        }

        [HttpGet("GetUser/{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var row = await _context.Users.Where(x => x.Id == userId).FirstOrDefaultAsync();
            if (row == null)
            {
                return NotFound($"User with ID {userId} not found.");
            }
            return Ok(row);
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // Returns validation errors
            }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("EditUser")]
        public async Task<IActionResult> EditUser([FromBody] User user)
            {
            var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);

            if (existingUser == null)
            {
                return NotFound($"User with Id {user.Id} not found.");
            }

            existingUser.Name = user.Name;
            existingUser.Occupation = user.Occupation;
            existingUser.Salary = user.Salary;

            await _context.SaveChangesAsync();
            return Ok(existingUser);
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var rows = await _context.Users.Where(x => x.Id == userId).ExecuteDeleteAsync();
            if (rows == null)
            {
                return NotFound();
            }
            return Ok(true);
        }

    }
}
