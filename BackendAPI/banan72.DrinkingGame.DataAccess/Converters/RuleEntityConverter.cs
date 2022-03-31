using banan72.DrinkingGame.Core;

namespace banan72.DrinkingGame.DataAccess.Converters
{
    public class RuleEntityConverter
    {
        public Rule Convert(RuleEntity entity)
        {
            return new Rule
            {
                Id = entity.Id,
                RuleName = entity.RuleName,
                Category = entity.Category,
            };
        }

        public RuleEntity Convert(Rule rule)
        {
            return new RuleEntity
            {
                Id = rule.Id,
                RuleName = rule.RuleName,
                Category = rule.Category,
            };
        }
    }
}