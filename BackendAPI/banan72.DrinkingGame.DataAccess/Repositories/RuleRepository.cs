using System.Collections.Generic;
using banan72.DrinkingGame.Core;
using banan72.DrinkingGame.Domain;

namespace banan72.DrinkingGame.DataAccess
{
    public class RuleRepository : IRuleRepository
    {
        private readonly MainDBContext _ctx;

        public RuleRepository(MainDBContext ctx)
        {
            _ctx = ctx;
        }
        
        public List<Rule> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Rule GetRule(int ruleId)
        {
            throw new System.NotImplementedException();
        }

        public Rule DeleteRule(int ruleId)
        {
            throw new System.NotImplementedException();
        }

        public Rule CreateRule(Rule ruleToCreate)
        {
            throw new System.NotImplementedException();
        }

        public Rule UpdateRule(Rule ruleToUpdate)
        {
            throw new System.NotImplementedException();
        }
    }
}