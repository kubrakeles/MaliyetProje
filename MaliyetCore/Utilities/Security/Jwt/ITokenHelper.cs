using MaliyetCore.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaliyetCore.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaim);//User bilgisine gore token üretecek, 
        //operationclaim üyenin rollerini token a ekletmek istediğiiz için ekliyoruz parametre olrak
    }
}
