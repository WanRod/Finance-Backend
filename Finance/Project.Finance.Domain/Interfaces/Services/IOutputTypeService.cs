﻿using Project.Finance.Domain.Entites;

namespace Project.Finance.Domain.Interfaces.Services;

public interface IOutputTypeService
{
    Task<List<OutputType>> GetAll();

    Task<OutputType?> GetById(Guid id);

    Task<OutputType> Insert(OutputType entity);

    Task<OutputType> Update(Guid id, OutputType entity);

    Task<OutputType> Delete(Guid id);
}
