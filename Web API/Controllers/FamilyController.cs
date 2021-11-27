using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FileData;
using Model;
using Microsoft.EntityFrameworkCore;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamilyController : ControllerBase
    {
        private IFamilyService familyService;

        public FamilyController(IFamilyService familyService)
        {
            this.familyService = familyService;
        }

        [HttpGet]
        public async Task<ActionResult<DbSet<Family>>> GetFamilies()
        {
            try{
                DbSet<Family> family = await familyService.GetFamilies();
                return Ok(family);
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("{id:int}/Adults")]
        public async Task<ActionResult<DbSet<Family>>> GetAdults([FromRoute]int  id)
        {
            try{
                IList<Adult> ad = await familyService.GetAdults(id);
                return Ok(ad);
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddFamily([FromBody]Family family)
        {
            try{
                await familyService.AddFamily(family);
                return Ok();
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("{id:int}/Adult")]
        public async Task<IActionResult> AddAdult([FromRoute]int  id, [FromBody]Adult adult)
        {
            try{
                Adult ad = await familyService.AddAdultToFamily(id, adult);
                return Ok(ad);
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

       

        [HttpPost]
        [Route("{id:int}/Child")]
        public async Task<IActionResult> AddChild([FromRoute]int  id, [FromBody]Child child)
        {
            try{
                Child ch = await familyService.AddChildToFamily(id, child);
                return Ok(ch);
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("{id:int}/Pet")]
        public async Task<IActionResult> AddPet([FromRoute]int  id, [FromBody]Pet pet)
        {
            try{
                Pet p = await familyService.AddPetToFamily(id, pet);
                return Ok(p);
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteFamily([FromRoute]int  id)
        {
            try{
                await familyService.RemoveFamily(id);
                return Ok();
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateFamily([FromBody]Family family, [FromRoute] int id)
        {
            try{
                await familyService.EditFamily(family);
                return Ok();
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
