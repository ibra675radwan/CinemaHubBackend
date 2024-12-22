using System;
using System.Collections.Generic;

namespace CinemaHub_DAL.Models;

public partial class Cinema
{
    public int CinemaId { get; set; }

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public int Capacity { get; set; }

    public string ContactInfo { get; set; } = null!;

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public virtual ICollection<Userwithcinema> Userwithcinemas { get; set; } = new List<Userwithcinema>();
}
