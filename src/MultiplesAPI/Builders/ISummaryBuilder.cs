using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiplesAPI.Builders
{
    public interface ISummaryBuilder
    {
        IDictionary<string, int> GetSummary();
        void IncrementSummary(string key);
    }
}
