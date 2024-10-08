﻿using MediatR;

namespace Project.Finance.Application.Commands.Output;

public class OutputDeleteRequest(Guid id) : IRequest
{
    public Guid Id { get; } = id;
}
