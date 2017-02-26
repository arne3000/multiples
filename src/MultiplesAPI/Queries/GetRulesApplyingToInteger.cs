using MultiplesAPI.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiplesAPI.Queries
{
    public class GetRulesApplyingToInteger : IQuery<int, IEnumerable<Rule>>
    {
        private DataContext context;
        public GetRulesApplyingToInteger(DataContext _context)
        {
            context = _context;
        }

        public IEnumerable<Rule> Execute(int value)
        {
            return context.Rules.Where(x => value.IsMultiple(x.MultipleValue));
        }
    }
}
