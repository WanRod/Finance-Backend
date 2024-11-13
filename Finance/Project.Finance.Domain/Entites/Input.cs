using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Finance.Domain.Entites;

[Table("input")]
public class Input
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("input_type_id")]
    public Guid InputTypeId { get; set; }

    [Column("description")]
    [MaxLength(100)]
    public required string Description { get; set; }

    [Column("value")]
    public decimal Value { get; set; }

    [Column("date")]
    public DateOnly Date { get; set; }

    [Column("created_by")]
    public Guid CreatedBy { get; set; }

    [ForeignKey("InputTypeId")]
    public required InputType InputType { get; set; }
}
