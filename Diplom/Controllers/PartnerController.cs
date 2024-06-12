using Diplom.Models;
using Microsoft.AspNetCore.Mvc;

namespace Diplom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PartnerController : ControllerBase
    {
        private DiplomContext db;
        public PartnerController(DiplomContext ctx)
        {
            db = ctx;
        }

        [HttpGet]
        public IEnumerable<User> GetPartners()
        {
            return db.Users.Where(p => p.Role == 2).ToList();
        }
    }
}
