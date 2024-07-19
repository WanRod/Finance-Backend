using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Finance.Domain.Entites;

[Table("input")]
public class Input
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("description")]
    public required string Description { get; set; }

    [Column("value")]
    public decimal Value { get; set; }

    [Column("date")]
    public DateOnly Date { get; set; }
}
