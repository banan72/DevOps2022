using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RuleController : ControllerBase
    {
        public RuleController()
        {
            //here we will add our service
        }

        [HttpGet]
        public ActionResult<RuleDto> GetAll()
        {
            try
            {
                var placeholder = new RuleDto();
                return Ok(placeholder);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
    }
}