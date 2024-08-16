using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Finance.Domain.Entites;

[Table("user")]
public class User
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }

    [MaxLength(50)]
    [Column("name")]
    public required string Name { get; set; }

    [Column("cpf_cnpj")]
    public required string CpfCnpj { get; set; }

    [Column("password")]
    public required string Password { get; set; }
}
