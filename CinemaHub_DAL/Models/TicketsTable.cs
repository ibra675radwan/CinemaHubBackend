using System;
using System.Collections.Generic;

namespace CinemaHub_DAL.Models;

public partial class TicketsTable
{
    public int TicketId { get; set; }

    public int UserId { get; set; }

    public int ShowtimeId { get; set; }

    public string? SeatNumber { get; set; }

    public decimal Price { get; set; }

    public DateTime BookingTime { get; set; }

    public virtual Showtime Showtime { get; set; } = null!;
}
