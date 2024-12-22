using CinemaHub_BLL.DTO.Payment;
using CinemaHub_BLL.Services.GenericServices;
using CinemaHub_BLL.Services.Payment;
using Microsoft.AspNetCore.Mvc;

namespace CinemaHub.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PaymentController : GenericController<PaymentDTO>
    {
        private readonly iPaymentService _iPaymentService;

        public PaymentController(iPaymentService iPaymentService) : base(iPaymentService) 
        {
            _iPaymentService = iPaymentService;
        }
    }
}
