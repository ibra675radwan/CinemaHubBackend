using System;
using System.Collections.Generic;

namespace CinemaHub_DAL.Models;

public partial class Movie
{
    public int MovieId { get; set; }

    public string? Title { get; set; }

    public DateOnly? ReleaseDate { get; set; }

    public int? Duration { get; set; }

    public decimal? Rating { get; set; }

    public int? GenreId { get; set; }

    public string? Description { get; set; }

    public string? PosterUrl { get; set; }

    public int? CinemaId { get; set; }

    public virtual Cinema? Cinema { get; set; }

    public virtual Genre? Genre { get; set; }
}
