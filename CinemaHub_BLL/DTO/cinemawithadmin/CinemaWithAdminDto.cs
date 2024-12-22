using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_BLL.DTO.cinemawithadmin
{
    public class CinemaWithAdminDTO
    {
        public int CinemaId { get; set; }
        public string CinemaName { get; set; } = string.Empty;
        public string AdminName { get; set; } = string.Empty;
        public string AdminUsername { get; set; } = string.Empty;
    }
}
