using System.Collections.Generic;

namespace banan72.DrinkingGame.Core
{
    public interface IRuleService
    {
        public List<Rule> GetAll();
        public Rule GetRule(int ruleId);
        public Rule DeleteRule(int ruleId);
        public Rule CreateRule(Rule ruleToCreate);
        public Rule UpdateRule(Rule ruleToUpdate);
    }
}