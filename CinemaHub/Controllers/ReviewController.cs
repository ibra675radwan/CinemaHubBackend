using CinemaHub_BLL.DTO.Review;
using CinemaHub_BLL.Services.GenericServices;
using CinemaHub_BLL.Services.Review;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace CinemaHub.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ReviewController : GenericController<ReviewDto>
    {
        private readonly iReviewService _iReviewService;

        public ReviewController(iReviewService iReviewService) : base(iReviewService) 
        {
            _iReviewService = iReviewService;
        }
    }
}
