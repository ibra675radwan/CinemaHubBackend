using AutoMapper;
using CinemaHub_BLL.Services.GenericServices;
using CinemaHub_DAL.Repositories._GenericRepositories;
using CinemaHub_DAL.Repositories.reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_BLL.Services.Review
{
    using Entity = CinemaHub_DAL.Models.Review;
    using Dto = CinemaHub_BLL.DTO.Review.ReviewDto;
    public class ReviewService : GenericServices<Entity , Dto> , iReviewService
        
    {
        private readonly iReviewRepositories _iReviewRepositories;
        private readonly IMapper _mapper;

        public ReviewService(iReviewRepositories iReviewRepositorie, IMapper mapper) : base(iReviewRepositorie, mapper)
        {
            _iReviewRepositories = iReviewRepositorie;
            _mapper = mapper;


        }
    }
}
