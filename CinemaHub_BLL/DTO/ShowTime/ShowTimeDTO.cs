using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_BLL.DTO.ShowTime
{
    public class ShowTimeDTO
    {
        public int ShowtimeId { get; set; }
        public int CinemaId { get; set; }
        public int MovieId { get; set; }
        public DateTime StartTime { get; set; }
    }
}
