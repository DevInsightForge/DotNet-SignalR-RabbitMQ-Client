using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models;

public partial class RefreshToken
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Token { get; set; }

    public string Browser { get; set; } = null!;

    public string System { get; set; } = null!;

    public string Device { get; set; } = null!;

    public DateTime ValidUntil { get; set; }

    public Guid? UserId { get; set; }

    public virtual User? User { get; set; }
}
