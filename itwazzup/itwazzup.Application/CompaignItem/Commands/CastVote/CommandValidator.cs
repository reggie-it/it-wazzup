using System;
using FluentValidation;

namespace itwazzup.Application.CompaignItem.Commands.CastVote
{
    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {

        }
    }
}