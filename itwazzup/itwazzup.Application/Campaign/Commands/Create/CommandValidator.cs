using System;
using FluentValidation;

namespace itwazzup.Application.Campaign.Commands.Create
{
    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(150);
            RuleFor(x => x.StartDate).GreaterThanOrEqualTo(DateTime.Now);
            RuleFor(x => x.EndDate).GreaterThanOrEqualTo(DateTime.Now);
            RuleFor(x => x.MaxVotes).GreaterThanOrEqualTo(1);
        }
    }
}