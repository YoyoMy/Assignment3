using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FileData;
using Model;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdultController : ControllerBase
    {
        private IFamilyService familyService;

        public AdultController(IFamilyService familyService)
        {
            this.familyService = familyService;
        }


        [HttpGet]
        public async Task<ActionResult<IList<Adult>>> GetAdults()
        {
            try{
                IList<Adult> adults = await familyService.GetAllAdults();
                return Ok(adults);
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Adult>> GetAdult([FromRoute] int id)
        {
            try{
                Adult ad= await familyService.GetAdult(id);
                return Ok(ad);
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

     /* [HttpPost]
       [Route("{id:int}")]
        public async Task<IActionResult> UpdateAdults([FromRoute]int  id, [FromBody]Adult adult)
        {
            try{
                await familyService.EditAdult(adult);
                return Ok();
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }*/
/*
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAdults([FromRoute]int  id)
        {
            try{
                await adultService.DeleteAdultsAsync(id);
                return Ok();
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateAdults([FromBody]Adult adult, [FromRoute] int id)
        {
            try{
                await adultService.UpdateAdultsAsync(adult);
                return Ok();
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }*/
    }
}
