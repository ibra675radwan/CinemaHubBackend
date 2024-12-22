using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_BLL.DTO.Payment
{
    public class PaymentDTO
    {
        public int PaymentId { get; set; }
        public int TicketId { get; set; }

        public decimal Amount { get; set; }
    }
}
