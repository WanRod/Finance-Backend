﻿using Project.Finance.Domain.Entites;

namespace Project.Finance.Domain.Interfaces.Services;

public interface IOutputTypeService
{
    Task<List<OutputType>> GetAll();

    Task<OutputType?> GetById(Guid id);

    Task Insert(OutputType entity);

    Task Update(Guid id, OutputType entity);

    Task Delete(Guid id);
}
