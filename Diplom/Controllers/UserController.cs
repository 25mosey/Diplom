using Diplom.Models;
using Microsoft.AspNetCore.Mvc;

namespace Diplom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private DiplomContext db;
        public UserController(DiplomContext ctx)
        {
            db = ctx;
        }
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return db.Users.ToList();
        }
        [HttpGet("{id}")]
        public IEnumerable<User> GetUsers(int id)
        {
            return db.Users.Where(p => p.UserId == id).ToList();
        }
        [HttpPost]
        public void SaveNews([FromBody] User users)
        {
            if (users != null)
            {
                db.Users.Add(users);
                db.SaveChanges();
            }
        }
        [HttpPut]
        public async Task<ActionResult<User>> Put(User users)
        {

            if (users == null)
            {
                return BadRequest();
            }
            if (!db.Users.Any(x => x.UserId == users.UserId))
            {
                return NotFound();
            }
            db.Update(users);
            await db.SaveChangesAsync();
            return Ok(users);

        }
        [HttpDelete("{id}")]
        public void DeleteUser(long id)
        {
            db.Users.Remove(db.Users.Where(p => p.UserId == id).FirstOrDefault()!);
            db.SaveChanges();
        }
    }
}
