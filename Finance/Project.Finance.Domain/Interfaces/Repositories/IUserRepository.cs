﻿using Project.Finance.Domain.Entites;

namespace Project.Finance.Domain.Interfaces.Repositories;

public interface IUserRepository
{
    Task<User?> GetData(Guid id);

    Task<User?> GetByCpfCnpj(string cpfCnpj);

    Task<User> Insert(User entity);

    Task Update(Guid id, User entity);

    Task Delete(Guid id);
}
