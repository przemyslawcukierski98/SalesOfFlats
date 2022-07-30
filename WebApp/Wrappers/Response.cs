using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Wrappers
{
    public class Response<T> : Response
    {
        public T Data { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public Response()
        {

        }

        public Response(T data)
        {
            Data = data;
            Succeded = true;
        }
    }

    public class Response
    {
        public bool Succeded { get; set; }
        public string Message { get; set; }

        public Response()
        {

        }

        public Response(bool succeded, string message)
        {
            Succeded = succeded;
            Message = message;
        }
    }
}
