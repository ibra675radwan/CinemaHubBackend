using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaHub_BLL.wrapping
{
    public class APIResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public APIResponse()
        {
            Success = true;
        }
        public APIResponse(T obj)
        {
            Data = obj;
            Success = true;
        }
    }
}

