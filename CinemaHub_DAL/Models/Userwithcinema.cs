using System;
using System.Collections.Generic;

namespace CinemaHub_DAL.Models;

public partial class Userwithcinema
{
    public int UserwithcinemaId { get; set; }

    public int? UserId { get; set; }

    public int? CinemaId { get; set; }

    public virtual Cinema? Cinema { get; set; }

    public virtual User? User { get; set; }
}
