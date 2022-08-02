using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaliyetCore.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, success: false, message)
        {

        }
        public ErrorDataResult(T data, bool success) : base(data, success: false)
        {

        }
        public ErrorDataResult(string message) : base(default, success: false)
        {

        }
        public ErrorDataResult() : base(default, success: false)
        {

        }

    }
}
    