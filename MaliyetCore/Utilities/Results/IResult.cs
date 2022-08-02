using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaliyetCore.Utilities.Results
{
    public interface IResult
    {
        public bool Success { get; }
        public String Message { get; }
      
    }
}
