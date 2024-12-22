using AutoMapper;
using CinemaHub_BLL.Services.GenericServices;
using CinemaHub_DAL.Repositories.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_BLL.Services.Payment
{
    using Entity = CinemaHub_DAL.Models.PaymentsTable;
    using Dto = CinemaHub_BLL.DTO.Payment.PaymentDTO;
    public class PaymentService : GenericServices<Entity, Dto> , iPaymentService
    {
        private readonly iPaymentRepositorie _iPaymentRepositorie;
        private readonly IMapper _mapper;

        public PaymentService(iPaymentRepositorie iPaymentRepositorie, IMapper mapper) : base(iPaymentRepositorie, mapper)
        {
            _iPaymentRepositorie = iPaymentRepositorie;
            _mapper = mapper;
        }
    }
}
