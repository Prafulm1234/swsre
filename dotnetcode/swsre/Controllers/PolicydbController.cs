using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using swsre.Models;

namespace swsre.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private readonly swsredbContext _context;

        public PolicyController(swsredbContext context)
        {
            _context = context;
        }
		

   [HttpGet]

   public async Task<ActionResult<List<Policy>>> GetPolicy()
   {
		return Ok(await _context.TPOLICY.ToListAsync());
   }
		
		



		





		

	[HttpPost]

	public async Task<ActionResult<Store>> CreatePolicy(Policy mdlPostPyload)
	{
		_context.TPOLICY.Add(mdlPostPyload);
		await _context.SaveChangesAsync();
		return CreatedAtAction("GetPolicy", new { id = mdlPostPyload.POLICYID }, mdlPostPyload);
	}
		



		


    }
}
