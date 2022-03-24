using System.Collections.Generic;
using banan72.DrinkingGame.Core;
using WebApplication.Dto;

namespace WebApplication.Converters
{
    public class RuleDtoConverter
    {
        public Rule Convert(RuleDto dto)
        {
            return new Rule
            {
                Id = dto.Id,
                RuleName = dto.RuleName,
                Category = dto.Category
            };
        }
        
        public RuleDto Convert(Rule rule)
        {
            return new RuleDto
            {
                Id = rule.Id,
                RuleName = rule.RuleName,
                Category = rule.Category
            };
        }
        
        public List<RuleDto> Convert(List<Rule> ruleList)
        {
            List<RuleDto> returnList = new List<RuleDto>();
            foreach (Rule r in ruleList)
            {
                returnList.Add(Convert(r));
            }

            return returnList;
        }
    }
}