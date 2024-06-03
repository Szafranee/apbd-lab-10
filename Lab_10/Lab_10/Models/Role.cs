using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_10.Models;

[Table("Roles")]
public class Role
{
    [Key]
    [Column("PK_role")]
    public int RoleId { get; set; }

    [Column("name")]
    [MaxLength(100)]
    public string Name { get; set; }

    public IEnumerable<Account> Accounts { get; set; } = [];
}