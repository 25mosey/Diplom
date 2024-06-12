using Diplom.Models;
using Microsoft.AspNetCore.Mvc;

namespace Diplom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContractController : ControllerBase
    {
        private DiplomContext db;
        public ContractController(DiplomContext ctx)
        {
            db = ctx;
        }

        [HttpPost]
        public void SaveContract([FromBody] Contract contract)
        {
            if (contract != null)
            {
                db.Contracts.Add(contract);
                db.SaveChanges();
            }
        }
        [HttpGet]
        public IEnumerable<Contract> GetContracts()
        {
            return db.Contracts.ToList();
        }
        [HttpGet("{id}")]
        public IEnumerable<Contract> GetContracts(int id)
        {
            return db.Contracts.Where(p => p.PartnerId == id).ToList();
        }
        [HttpPut]
        public async Task<ActionResult<Contract>> Put(Contract contracts)
        {
            if (contracts == null)
            {
                return BadRequest();
            }
            if (!db.Contracts.Any(x => x.IdContract == contracts.IdContract))
            {
                return NotFound();
            }
            db.Update(contracts);
            await db.SaveChangesAsync();
            return Ok(contracts);
        }
        [HttpDelete("{id}")]
        public void DeleteContract(long id)
        {
            db.Contracts.Remove(db.Contracts.Where(p => p.IdContract == id).FirstOrDefault()!);
            db.SaveChanges();
        }
    }
}
