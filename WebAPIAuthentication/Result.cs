using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIAuthentication
{
    public class Result
    {
        public string version { get; set; }
        public int StatusCode  { get; set; }
        public string StatusMessage { get; set; }
        public List<object> Data { get; set; }


    }
}
