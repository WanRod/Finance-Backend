namespace Project.Finance.Application.Commands.Dashboard;

public class DashboardOutputTypeResponse
{
    public required string Description { get; set; }

    public int Amount { get; set; }

    public decimal Total { get; set; }
}
