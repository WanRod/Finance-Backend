namespace Project.Finance.Application.Commands.Dashboard;

public class DashboardResponse
{
    public decimal TotalInput { get; set; }

    public decimal TotalOutput { get; set; }

    public decimal PercentSpent { get; set; }

    public decimal RemainingAmount { get; set; }

    public List<MonthlyDashboardResponse> Monthly { get; set; } = [];

    public List<DashboardOutputTypesResponse> OutputTypes { get; set; } = [];
}
