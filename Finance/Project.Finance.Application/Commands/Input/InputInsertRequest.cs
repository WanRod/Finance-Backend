﻿using MediatR;

namespace Project.Finance.Application.Commands.Input;

public class InputInsertRequest : IRequest
{
    public required string Description { get; set; }

    public decimal Value { get; set; }

    public DateOnly Date { get; set; }
}
