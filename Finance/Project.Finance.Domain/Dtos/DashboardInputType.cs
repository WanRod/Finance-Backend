namespace Project.Finance.Domain.Dtos;

public class DashboardInputType
{
    public required string Description { get; set; }

    public int Amount { get; set; }

    public decimal Total { get; set; }
}
