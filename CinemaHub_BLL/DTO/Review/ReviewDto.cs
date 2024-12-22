using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_BLL.DTO.Review
{
    public class ReviewDto
    {
        public int ReviewId { get; set; }

        public int UserId { get; set; }

        public int MovieId { get; set; }

        public decimal Rating { get; set; }

        public string ReviewText { get; set; } = null!;
    }
}
