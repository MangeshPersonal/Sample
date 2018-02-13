using System;
using System.Collections.Generic;
using System.Text;
using DataModels;

namespace Repository.DataProviders
{
    class TestRepository
    {
        public Result GetData()
        {
            return new Result()
            {
                Data = null,
                DataCount = 1,StatusCode = 100,StatusMessage = "Good"
            };
        }
    }

}
