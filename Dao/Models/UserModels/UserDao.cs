using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao.Entities;
namespace Dao.Models.UserModels
{
    public class UserDao : IUserDao
    {
        private readonly CMMdbEntities _connection;
        public UserDao(CMMdbEntities connection)
        {
            _connection = connection;
        }
        public Login GetLoginDetails(string loginId, string password)
        {
            var login = _connection.Logins.Where(m => m.LoginId == loginId && m.Password == password).FirstOrDefault();
            return login;
        }

        public User GetUserDetailByUserId(int userId)
        {
            var userDetail = _connection.Users.Where(m => m.UserId == userId).FirstOrDefault();
            return userDetail;
        }

        
    }
}
