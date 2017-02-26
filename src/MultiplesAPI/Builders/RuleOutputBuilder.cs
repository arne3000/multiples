using MultiplesAPI.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiplesAPI.Builders
{
    public class RuleOutputBuilder : IBuilder<IEnumerable<Rule>, string>
    {
        public string Build(IEnumerable<Rule> rules)
        {
            if (rules == null)
            {
                return null;
            }

            return string.Concat(rules.Select(x => x.OutputText));
        }
    }
}
