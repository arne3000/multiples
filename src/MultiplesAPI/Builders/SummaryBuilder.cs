using MultiplesAPI.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiplesAPI.Builders
{
    public class SummaryBuilder : ISummaryBuilder
    {
        private IDictionary<string, int> Summary;
        private string DefaultValue = "integer";

        public SummaryBuilder()
        {
            Summary = new Dictionary<string, int>();
        }

        public IDictionary<string, int> GetSummary()
        {
            return Summary;
        }

        public void IncrementSummary(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                key = DefaultValue;
            }

            if (Summary.ContainsKey(key) == false)
            {
                Summary[key] = 0;
            }
            Summary[key]++;
        }
    }
}
