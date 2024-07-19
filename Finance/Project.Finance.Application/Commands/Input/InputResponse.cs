﻿namespace Project.Finance.Application.Commands.Input;

public class InputResponse
{
    public Guid Id { get; set; }

    public required string Description { get; set; }

    public decimal Value { get; set; }

    public DateOnly Date { get; set; }
}
