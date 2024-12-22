using AutoMapper;
using CinemaHub_BLL.wrapping;
using CinemaHub_DAL.Repositories._GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_BLL.Services.GenericServices
{
    public class GenericServices<Entity , Dto> : iGenericServices <Dto>
        where Entity : class
        where Dto : class
    {
        private readonly iGenericRepositories<Entity> _genericRepository;
        private readonly IMapper _mapper;
        public GenericServices(iGenericRepositories<Entity> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public APIResponse<IEnumerable<Dto>> GetAll()
        {
            var response = new APIResponse<IEnumerable<Dto>>();
            var result = _genericRepository.GetAll();
            response.Data = _mapper.Map<IEnumerable<Dto>>(result);
            return response;
        }

        public APIResponse<Dto> GetByID(int id)
        {
            var response = new APIResponse<Dto>();
            var result = _genericRepository.GetByID(id);
            response.Data = _mapper.Map<Dto>(result);
            return response;
        }
        public APIResponse<Dto> Add(Dto dto)
        {
            var response = new APIResponse<Dto>();
            var entity = _mapper.Map<Entity>(dto);
            if (entity == null)
            {
                throw new Exception("Null");


            }
            var result = _genericRepository.Add(entity);
            response.Data = _mapper.Map<Dto>(result);
            return response;
        }

        public virtual APIResponse<bool> Delete(int id)
        {
            var response = new APIResponse<bool>();
            response.Data = _genericRepository.Delete(id);
            return response;
        }

        public virtual APIResponse<bool> Delete(Dto dto)
        {
            var response = new APIResponse<bool>();
            var entity = _mapper.Map<Entity>(dto);
            response.Data = _genericRepository.Delete(entity);
            return response;
        }

        public APIResponse<Dto> Update(Dto dto)
        {
            var response = new APIResponse<Dto>();
            var entity = _mapper.Map<Entity>(dto);
            var result = _genericRepository.Update(entity);
            response.Data = _mapper.Map<Dto>(result);
            return response;
        }
    }
}
