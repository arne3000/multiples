using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiplesAPI.Builders
{
    public interface IRuleBuilder<RuleObject, InputObject, OutputObject> : IBuilder<InputObject, OutputObject>
    {
        IRuleBuilder<RuleObject, InputObject, OutputObject> ApplyRules(IEnumerable<RuleObject> rule);
    }
}
