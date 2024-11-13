using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Finance.Domain.Entites;

[Table("output")]
public class Output
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("output_type_id")]
    public Guid OutputTypeId { get; set; }

    [Column("description")]
    [MaxLength(100)]
    public required string Description { get; set; }

    [Column("value")]
    public decimal Value { get; set; }

    [Column("date")]
    public DateOnly Date { get; set; }

    [Column("created_by")]
    public Guid CreatedBy { get; set; }

    [ForeignKey("OutputTypeId")]
    public required OutputType OutputType { get; set; }
}
