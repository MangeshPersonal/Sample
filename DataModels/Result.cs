using System;
using System.Collections.Generic;
using System.Text;

namespace DataModels
{
   public class Result
    {
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<object> Data { get; set; }
        public int DataCount { get; set; }
    }
}
