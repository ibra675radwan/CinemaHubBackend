using System;
using System.Collections.Generic;

namespace CinemaHub_DAL.Models;

public partial class PaymentsTable
{
    public int PaymentId { get; set; }

    public int UserId { get; set; }

    public int TicketId { get; set; }

    public decimal Amount { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public DateTime PaymentTime { get; set; }
}
