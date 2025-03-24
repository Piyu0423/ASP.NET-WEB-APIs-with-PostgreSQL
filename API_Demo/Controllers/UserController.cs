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

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("EditUser")]
        public async Task<IActionResult> EditUser([FromBody] User user)
            {
            var rows = await _context.Users.Where(x=>x.Id == user.Id)
            .ExecuteUpdateAsync(x=>x.SetProperty(x=>x.Name, user.Name));
            return Ok(rows);
            }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var rows = await _context.Users.Where(x => x.Id == userId).ExecuteDeleteAsync();
            return Ok(true);
        }

    }
}
