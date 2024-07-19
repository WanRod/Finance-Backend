﻿using MediatR;

namespace Project.Finance.Application.Commands.Input;

public class InputUpdateRequest : IRequest<InputResponse>
{
    public Guid Id { get; set; }

    public required string Description { get; set; }

    public decimal Value { get; set; }

    public DateOnly Date { get; set; }
}
