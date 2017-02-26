using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MultiplesAPI.Models.Output;
using MultiplesAPI.Models.Data;
using MultiplesAPI.Builders;
using MultiplesAPI.Queries;

namespace MultiplesAPI.Controllers
{
    [Route("api/[controller]")]
    public class MultiplesController : Controller
    {
        private readonly DataContext DataContext;
        private IBuilder<IEnumerable<int>, SummaryResult> SummaryResultBuilder;

        public MultiplesController(DataContext dataContext, IBuilder<IEnumerable<int>, SummaryResult> summaryResultBuilder)
        {
            DataContext = dataContext;
            SummaryResultBuilder = summaryResultBuilder;
        }

        [HttpGet]
        public IActionResult Get(int rangeStart, int rangeEnd)
        {
            var range = Extensions.CreateSquenceFromStartEnd(rangeStart, rangeEnd);
            var result = SummaryResultBuilder.Build(range);
            return Ok(result);
        }
    }
}
