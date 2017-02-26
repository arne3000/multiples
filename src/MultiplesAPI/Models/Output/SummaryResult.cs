using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiplesAPI.Models.Output
{
    public class SummaryResult
    {
        public string result { get; set; }
        public IDictionary<string, int> summary { get; set; }
    }
}
