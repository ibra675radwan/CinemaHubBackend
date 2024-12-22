using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_BLL.DTO.Cinema
{
    public class CinemaDTO
    {

        public int CinemaId { get; set; }

        public string Name { get; set; } = null!;

        public string Location { get; set; } = null!;
        public string ContactInfo { get; set; } = null!;


    }
}
