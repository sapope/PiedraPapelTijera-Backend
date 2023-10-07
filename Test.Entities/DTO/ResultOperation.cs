using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Entities.DTO
{
    public class ResultOperation
    {
        public ResultOperation() 
        {
            stateOperation = true;
            message = "";
            exception = "";
        }

        public bool stateOperation { get; set; }

        public string message { get; set; }

        public string exception { get; set; }
    }

    public class ResultOperation<T>:ResultOperation 
    {
        public T result { get; set; }

    }
}
