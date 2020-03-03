using System;
using FluentValidation;

namespace itwazzup.Application.CampaignItem.Commands.CastVote
{
    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {

        }
    }
}