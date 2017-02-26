using MultiplesAPI.Models.Data;
using MultiplesAPI.Models.Output;
using MultiplesAPI.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiplesAPI.Builders
{
    public class SummaryResultBuilder : IBuilder<IEnumerable<int>, SummaryResult>
    {
        private ISummaryBuilder SummaryBuilder;
        private IBuilder<IEnumerable<int>, string> ResultListBuilder;
        public SummaryResultBuilder(IBuilder<IEnumerable<int>, string> resultListBuilder, ISummaryBuilder summaryBuilder)
        {
            ResultListBuilder = resultListBuilder;
            SummaryBuilder = summaryBuilder;
        }
        
        public SummaryResult Build(IEnumerable<int> input)
        {
            return new SummaryResult()
            {
                result = ResultListBuilder.Build(input),
                summary = SummaryBuilder.GetSummary()
            };
        }  
    }
}
