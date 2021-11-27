using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FileData;
using Model;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChildController : ControllerBase
    {
        private IFamilyService familyService;

        public ChildController(IFamilyService familyService)
        {
            this.familyService = familyService;
        }


        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Child>> GetChild([FromRoute] int id)
        {
            try
            {
                Child ad = await familyService.GetChild(id);
                return Ok(ad);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

       [HttpPost]
        [Route("{id:int}/Interest")]
        public async Task<IActionResult> AddInterest([FromRoute] int id, [FromBody] Interest interest)
        {
            try
            {
                Interest intr = await familyService.AddInterest(id, interest);
                return Ok(intr);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
