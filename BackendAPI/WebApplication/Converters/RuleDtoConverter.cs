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
                RuleName = dto.ruleName,
                Category = dto.category
            };
        }
        
        public RuleDto Convert(Rule rule)
        {
            return new RuleDto
            {
                ruleName = rule.RuleName,
                category = rule.Category
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