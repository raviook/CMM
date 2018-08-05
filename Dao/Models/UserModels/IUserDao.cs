using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao.Entities;
namespace Dao.Models.UserModels
{
  public interface IUserDao
    {
        Login GetLoginDetails(string loginId, string password);
        User GetUserDetailByUserId(int userId);
    }
}
