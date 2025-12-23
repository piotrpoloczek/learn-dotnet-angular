using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    public class MembersController(AppDbContext context) : BaseApiController
    {
        
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AppUser>>> GetMembers()
        {
            var members = await context.Users.ToListAsync();
            return members;
        }


        [Authorize]
        [HttpGet("{id}")] // localhost:5003/api/members/bob-id
        public async Task<ActionResult<AppUser>> GetMember(string id)
        {
            var members = await context.Users.FindAsync(id);

            if (members == null) return NotFound();

            return members;
        }
    }
}
