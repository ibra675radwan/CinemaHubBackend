using System;
using System.Collections.Generic;

namespace CinemaHub_DAL.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Phone { get; set; }

    public string Username { get; set; } = null!;

    public int? CinemaId { get; set; }

    public int RoleId { get; set; }

    public virtual Cinema? Cinema { get; set; }

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual Role Role { get; set; } = null!;

    public virtual ICollection<Userwithcinema> Userwithcinemas { get; set; } = new List<Userwithcinema>();
}
