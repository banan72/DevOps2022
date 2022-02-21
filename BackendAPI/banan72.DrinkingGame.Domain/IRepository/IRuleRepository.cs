using System.Collections.Generic;
using banan72.DrinkingGame.Core;

namespace banan72.DrinkingGame.Domain
{
    public interface IRuleRepository
    {
        public List<Rule> GetAll();
        public Rule GetRule(int ruleId);
        public Rule DeleteRule(int ruleId);
        public Rule CreateRule(Rule ruleToCreate);
        public Rule UpdateRule(Rule ruleToUpdate);
    }
    }
