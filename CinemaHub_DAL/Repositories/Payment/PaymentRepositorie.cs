using CinemaHub_DAL.Models;
using CinemaHub_DAL.Repositories._GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_DAL.Repositories.Payment
{
    public class PaymentRepositorie : GenericRepositories<PaymentsTable> , iPaymentRepositorie
    {
        public PaymentRepositorie(CinemaHubContext cinemaHubContext) : base(cinemaHubContext)
        {



        }
    }
}
