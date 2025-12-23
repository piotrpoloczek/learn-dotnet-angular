using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Entities;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController(AppDbContext context) : ControllerBase
    {
        
        [HttpGet]
        public ActionResult<IReadOnlyList<AppUser>> GetMembers()
        {
            var members = context.Users.ToList();
            return members;
        }


        [HttpGet("{id}")] // localhost:5003/api/members/bob-id
        public ActionResult<AppUser> GetMember(string id)
        {
            var members = context.Users.Find(id);

            if (members == null) return NotFound();

            return members;
        }
    }
}
