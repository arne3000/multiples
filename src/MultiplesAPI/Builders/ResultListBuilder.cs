using MultiplesAPI.Models.Data;
using MultiplesAPI.Models.Output;
using MultiplesAPI.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiplesAPI.Builders
{
    public class ResultListBuilder : IBuilder<IEnumerable<int>, string>
    {
        private ISummaryBuilder SummaryBuilder;
        private IRuleBuilder<Rule, int, string> ResultBuilder;
        private IQuery<int, IEnumerable<Rule>> RuleQuery;
        private List<string> Results;
        public ResultListBuilder(IQuery<int, IEnumerable<Rule>> ruleQuery, IRuleBuilder<Rule, int, string> resultBuilder)
        {
            Results = new List<string>();
            RuleQuery = ruleQuery;
            ResultBuilder = resultBuilder;
        }
        
        public string Build(IEnumerable<int> input)
        {
            foreach (var value in input)
            {
                var rules = RuleQuery.Execute(value);
                var result = ResultBuilder.ApplyRules(rules).Build(value);
                Results.Add(result);
            }

            return string.Join(" ", Results);
        }  
    }
}
