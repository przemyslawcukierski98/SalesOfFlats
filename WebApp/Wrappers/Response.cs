using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Wrappers
{
    public class Response<T>
    {
        public T Data { get; set; }
        public bool Succeded { get; set; }

        public Response()
        {

        }

        public Response(T data)
        {
            Data = data;
            Succeded = true;
        }
    }
}
