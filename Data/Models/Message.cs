using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models;

public partial class Message
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Content { get; set; } = null!;

    public DateTime SentAt { get; set; }

    public Guid? UserId { get; set; }

    public Guid? ChatId { get; set; }

    public virtual Chat? Chat { get; set; }

    public virtual User? User { get; set; }
}
