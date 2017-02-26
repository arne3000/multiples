using MultiplesAPI.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiplesAPI.Builders
{
    public class ResultBuilder : IRuleBuilder<Rule, int, string>
    {
        private ISummaryBuilder SummaryBuilder;
        private IBuilder<IEnumerable<Rule>, string> RuleBuilder;
        private IEnumerable<Rule> Rules;

        public ResultBuilder(IBuilder<IEnumerable<Rule>, string> ruleBuilder, ISummaryBuilder summaryBuilder)
        {
            RuleBuilder = ruleBuilder;
            SummaryBuilder = summaryBuilder;
            Rules = null;
        }

        public IRuleBuilder<Rule, int, string> ApplyRules(IEnumerable<Rule> rules)
        {
            Rules = rules;
            return this;
        }

        public string Build(int input)
        {
            var ruleOutput = RuleBuilder.Build(Rules);

            SummaryBuilder.IncrementSummary(ruleOutput);

            if (string.IsNullOrEmpty(ruleOutput))
            {
                return input.ToString();
            }
            else
            {
                return ruleOutput;
            }            
        }
    }
}
