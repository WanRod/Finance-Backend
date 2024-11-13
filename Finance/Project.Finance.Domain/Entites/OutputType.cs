using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Finance.Domain.Entites;

[Table("output_type")]
public class OutputType
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [Column("description")]
    [MaxLength(100)]
    public required string Description { get; set; }

    [Column("created_by")]
    public Guid CreatedBy { get; set; }
}
