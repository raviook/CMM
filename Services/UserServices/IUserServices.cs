using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.UserServices
{
   public interface IUserServices
    {
        string UserAuthentication(string formData);

    }
}
