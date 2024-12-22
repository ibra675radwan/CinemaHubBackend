using System;
using System.Collections.Generic;

namespace CinemaHub_DAL.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public int UserId { get; set; }

    public int MovieId { get; set; }

    public decimal Rating { get; set; }

    public string ReviewText { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
