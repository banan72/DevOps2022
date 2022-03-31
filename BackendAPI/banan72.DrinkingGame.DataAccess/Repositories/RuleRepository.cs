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
            RuleEntity re = _ctx.Rule.Find(ruleId);
            return _rec.Convert(re);
        }

        public Rule DeleteRule(int ruleId)
        {
            var re = _ctx.Rule.Find(ruleId);
            _ctx.Rule.Remove(re);
            _ctx.SaveChanges();
            return _rec.Convert(re);
        }

        public Rule CreateRule(Rule ruleToCreate)
        {
            var pe = _rec.Convert(ruleToCreate);
            _ctx.Rule.Add(pe);
            _ctx.SaveChanges();
            return _rec.Convert(pe);
        }

        public Rule UpdateRule(Rule updatedRule, int id)
        {
            RuleEntity re = _ctx.Rule.Find(id);
            re.Category = updatedRule.Category;
            re.RuleName = updatedRule.RuleName;
            RuleEntity returnEntity = _ctx.Rule.Update(re).Entity;
            _ctx.SaveChanges();
            return _rec.Convert(returnEntity);
        }
    }
}