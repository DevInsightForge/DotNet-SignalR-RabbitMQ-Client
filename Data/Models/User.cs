using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models;

public partial class User
{

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public Guid Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime DateJoined { get; set; }

    public DateTime LastLogin { get; set; }

    public bool? IsActive { get; set; }

    public string Role { get; set; } = null!;

    public virtual ICollection<Message> Messages { get; } = new List<Message>();

    public virtual ICollection<RefreshToken> RefreshTokens { get; } = new List<RefreshToken>();

    public virtual ICollection<Chat> Chats { get; } = new List<Chat>();
}
