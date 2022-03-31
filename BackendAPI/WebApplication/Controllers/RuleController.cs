using System;
using System.Collections.Generic;
using banan72.DrinkingGame.Core;
using WebApplication.Dto;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Converters;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RuleController : ControllerBase
    {

        private readonly IRuleService _ruleService;
        private readonly RuleDtoConverter _ruleConverter;
        public RuleController(IRuleService ruleService)
        {
            _ruleService = ruleService;
            _ruleConverter = new RuleDtoConverter();
        }

        [HttpGet]
        public ActionResult<List<RuleDto>> GetAll()
        {
            try
            {
                return Ok(_ruleConverter.Convert(_ruleService.GetAll()));
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
                RuleName = ruleDto.ruleName,
                Category = ruleDto.category,
            };
            var ruleCreated =_ruleService.CreateRule(ruleToCreate);
            return Created($"https://localhost/api {ruleCreated.Id}", ruleCreated);
        }

        [HttpPut("{id:int}")]

        public ActionResult<RuleDto> UpdateRule(int id, [FromBody] RuleDto ruleToUpdate)
        {
            return Ok(_ruleService.UpdateRule(new Rule()
                {
                    RuleName = ruleToUpdate.ruleName,
                    Category = ruleToUpdate.category,
                }, 
                id
            ));
        }

        [HttpDelete("{id:int}")]
        public ActionResult<RuleDto> DeleteRule(int id)
        {
            var rule = _ruleService.DeleteRule(id);
            var dto = new RuleDto
            {
                ruleName = rule.RuleName,
                category = rule.Category,
            };
            return Ok(dto);
        }
        
    }
}