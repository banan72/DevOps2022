using System;
using banan72.DrinkingGame.Core;
using WebApplication.Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RuleController : ControllerBase
    {

        private readonly IRuleService _ruleService;
        public RuleController(IRuleService ruleService)
        {
            _ruleService = ruleService;
        }

        [HttpGet]
        public ActionResult<RuleDto> GetAll(int id)
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
        
        [HttpPost(nameof(CreateRule))]

        public ActionResult<RuleDto> CreateRule([FromBody] RuleDto ruleDto)
        {
            var ruleToCreate = new Rule()
            {
                RuleName = ruleDto.RuleName,
                Category = ruleDto.Category,
            };
            var ruleCreated =_ruleService.CreateRule(ruleToCreate);
            return Created($"https://localhost/api {ruleCreated.Id}", ruleCreated);
        }

        [HttpPut("{id:int}")]

        public ActionResult<RuleDto> UpdateRule(int id, [FromBody] RuleDto ruleToUpdate)
        {
            return Ok(_ruleService.UpdateRule(new Rule()
                {
                    RuleName = ruleToUpdate.RuleName,
                    Category = ruleToUpdate.Category,
                }
            ));
        }

        [HttpDelete("{id:int}")]
        public ActionResult<RuleDto> DeleteRule(int id)
        {
            var rule = _ruleService.DeleteRule(id);
            var dto = new RuleDto
            {
                Id = rule.Id,
                RuleName = rule.RuleName,
                Category = rule.Category,
            };
            return Ok(dto);
        }
        
    }
}