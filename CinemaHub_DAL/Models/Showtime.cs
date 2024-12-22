using System;
using System.Collections.Generic;

namespace CinemaHub_DAL.Models;

public partial class Showtime
{
    public int ShowtimeId { get; set; }

    public int? CinemaId { get; set; }

    public int? MovieId { get; set; }

    public DateTime? StartTime { get; set; }

    public int AvailableSeats { get; set; }

    public virtual ICollection<TicketsTable> TicketsTables { get; set; } = new List<TicketsTable>();
}
