﻿using Microsoft.EntityFrameworkCore;
using Project.Finance.Domain.Entites;
using Project.Finance.Domain.Interfaces;
using Project.Finance.Domain.Interfaces.Repositories;

namespace Project.Finance.Infrastructure.Repositories;

public class OutputRepository(FinanceDbContext dbContext, IUserContext userContext) : IOutputRepository
{
    public IQueryable<Output> AsQueryable()
    {
        return dbContext.OutputDbSet
            .Include(e => e.OutputType)
            .Where(e => e.CreatedBy == userContext.UserId)
            .AsQueryable();
    }

    public async Task<List<Output>> GetAll(int quantity = 20)
    {
        return await AsQueryable().OrderByDescending(e => e.Date).Take(quantity).ToListAsync();
    }

    public async Task<Output?> GetById(Guid id)
    {
        return await AsQueryable().FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task Insert(Output entity)
    {
        entity.CreatedBy = userContext.UserId;

        dbContext.OutputDbSet.Add(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task Update(Guid id, Output entity)
    {
        var currentyEntity = await AsQueryable().FirstOrDefaultAsync(e => e.Id == id) ?? throw new Exception("A saída não foi encontrada.");
        entity.CreatedBy = currentyEntity.CreatedBy;

        dbContext.Update(currentyEntity).CurrentValues.SetValues(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var entity = await AsQueryable().FirstOrDefaultAsync(e => e.Id == id) ?? throw new Exception("A saída não foi encontrada.");

        dbContext.OutputDbSet.Remove(entity);
        await dbContext.SaveChangesAsync();
    }
}
