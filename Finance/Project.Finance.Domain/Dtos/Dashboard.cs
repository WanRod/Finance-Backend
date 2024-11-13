namespace Project.Finance.Domain.Dtos;

public class Dashboard
{
    public decimal TotalInput { get; set; }

    public decimal TotalOutput { get; set; }

    public decimal PercentSpent { get; set; }

    public decimal RemainingAmount { get; set; }

    public List<MonthlyDashboard> Monthly { get; set; } = [];

    public List<DashboardInputType> InputTypes { get; set; } = [];

    public List<DashboardOutputType> OutputTypes { get; set; } = [];
}
