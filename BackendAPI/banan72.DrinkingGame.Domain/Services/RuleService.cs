using System.Collections.Generic;
using System.IO;
using banan72.DrinkingGame.Core;

namespace banan72.DrinkingGame.Domain
{
    public class RuleService : IRuleService

    {
        private readonly IRuleRepository _ruleRepo;

        public RuleService(IRuleRepository ruleRepository)
        {
            if (ruleRepository == null)
            {
                throw new InvalidDataException("RuleRepository cannot be Null");
            }

            _ruleRepo = ruleRepository;
        }
        
        public List<Rule> GetAll()
        {
            return _ruleRepo.GetAll();
        }

        public Rule GetRule(int ruleId)
        {
            return _ruleRepo.GetRule(ruleId);
        }

        public Rule DeleteRule(int ruleId)
        {
            return _ruleRepo.DeleteRule(ruleId);
        }

        public Rule CreateRule(Rule ruleToCreate)
        {
            return _ruleRepo.CreateRule(ruleToCreate);
        }

        public Rule UpdateRule(Rule ruleToUpdate)
        {
            return _ruleRepo.UpdateRule(ruleToUpdate);
        }
    }
}