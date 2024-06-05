using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models;

[Table("Roles")]
public class Role
{
    [Key]
    [Column("PK_role")]
    public int Role_Id { get; set; }
    
    public virtual ICollection<Account> Accounts { set; get; } = null;
    
    [Column("name")]
    [MaxLength(100)]
    public string Name { get; set; }
}