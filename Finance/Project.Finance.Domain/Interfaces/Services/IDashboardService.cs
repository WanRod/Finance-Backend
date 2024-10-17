﻿using Project.Finance.Domain.Data;

namespace Project.Finance.Domain.Interfaces.Services;

public interface IDashboardService
{
    Task<List<int>> GetAvailableYears();

    Task<Dashboard> GetData(int year, int month);
}
