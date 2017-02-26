using MultiplesAPI.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MultiplesAPI.Commands
{
    public class RuleCommandHandler : BaseCommandHandler<RuleCommand, Rule>
    {
        private int MinMultiple = 1;
        private int MaxMultiple = 1000;
        private Regex NonAlphanumericRegex = new Regex("[^a-zA-Z0-9 -]");


        protected override Rule CreateNewEntity()
        {
            return new Rule
            {
                MultipleValue = 1,
                OutputText = ""
            };
        }

        protected override Rule Map(Rule entity, RuleCommand command)
        {
            entity.MultipleValue = command.Multiple;
            entity.OutputText = command.Output;
            return entity;
        }

        protected override Exception Validate(RuleCommand command)
        {
            if (command.Multiple < MinMultiple || command.Multiple > MaxMultiple)
            {
                return new ArgumentOutOfRangeException(nameof(command.Multiple), $"value has to be between {MinMultiple} and {MaxMultiple}");
            }

            if (string.IsNullOrWhiteSpace(command.Output))
            {
                return new FormatException($"{nameof(command.Output)} is null or only contains whitespace");
            }

            if (NonAlphanumericRegex.IsMatch(command.Output))
            {
                return new FormatException($"Contains non alphanumeric characters in {nameof(command.Output)}");
            }

            return null;       
        }
    }
}
