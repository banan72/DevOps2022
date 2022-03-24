using System.Collections.Generic;
using System.IO;
using System.Linq;
using banan72.DrinkingGame.Core;
using banan72.DrinkingGame.Domain;
using banan72.DrinkingGame.DataAccess.Converters;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace banan72.DrinkingGame.DataAccess
{
    public class RuleRepository : IRuleRepository
    {
        private readonly MainDBContext _ctx;
        private readonly RuleEntityConverter _rec;
        public RuleRepository(MainDBContext ctx)
        {
            _ctx = ctx ?? throw new InvalidDataException("Player Repository must have a DBContext");
            _rec = new RuleEntityConverter();
        }
        
        public List<Rule> GetAll()
        {
            return _ctx.Rule.Select(re => _rec.Convert(re)).ToList();
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