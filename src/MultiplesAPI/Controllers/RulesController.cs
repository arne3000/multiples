using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultiplesAPI.Models.Output;
using MultiplesAPI.Models.Data;
using System.Text.RegularExpressions;
using MultiplesAPI.Commands;

namespace MultiplesAPI.Controllers
{
    [Route("api/[controller]")]
    public class RulesController : Controller
    {
        private readonly DataContext DataContext;
        private ICommandHandler<RuleCommand, Rule> RuleCommandHandler;

        public RulesController(DataContext dataContext, ICommandHandler<RuleCommand, Rule> ruleCommandHandler)
        {
            DataContext = dataContext;
            RuleCommandHandler = ruleCommandHandler;
        }

        [HttpGet]
        public IEnumerable<Rule> Get()
        {
            return DataContext.Rules;
        }
        
        [HttpGet("{id}")]
        public async Task<Rule> Get(int id)
        {
            return await DataContext.Rules.FindAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post(int multiple, string output)
        {
            var result = RuleCommandHandler.Execute(new RuleCommand
            {
                Multiple = multiple,
                Output = output
            });
            await DataContext.Rules.AddAsync(result);
            await DataContext.SaveChangesAsync();
            return Ok(true);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, int multiple, string output)
        {
            var rule = await DataContext.Rules.FindAsync(id);
            RuleCommandHandler.BindEntity(rule).Execute(new RuleCommand
            {
                Multiple = multiple,
                Output = output
            });
            await DataContext.SaveChangesAsync();
            return Ok(true);
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var rule = await DataContext.Rules.FindAsync(id);
            DataContext.Remove(rule);
            await DataContext.SaveChangesAsync();
            return true;
        }
    }
}
