using System;
using System.Collections.Generic;

namespace CinemaHub_DAL.Models;

public partial class AuditLog
{
    public int LogId { get; set; }

    public string? Action { get; set; }

    public int? UserId { get; set; }

    public DateTime? Timestamp { get; set; }
}
