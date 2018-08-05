using Dao.Models.UserModels;
using Newtonsoft.Json;
using System.Collections.Generic;
namespace Services.UserServices
{
    public class UserServices : IUserServices
    {
        private readonly IUserDao _userDao;
        public UserServices(IUserDao userDao)
        {
            _userDao = userDao;
        }
        public string UserAuthentication(string formData)
        {
            Dictionary<string, string> dictFormData = new Dictionary<string, string>();
            dictFormData = JsonConvert.DeserializeObject<Dictionary<string, string>>(formData);
            string loginId = dictFormData["LoginId"];
            string password = dictFormData["Password"];
            string response = null;
            var loginDetails = _userDao.GetLoginDetails(loginId, password);
            if (loginDetails != null)
            {
                var userDetails = _userDao.GetUserDetailByUserId(loginDetails.UserId);
                Dictionary<string, object> dict = new Dictionary<string, object>();
                dict.Add("loginDetails", loginDetails);
                dict.Add("userDetails", userDetails);
                response = JsonConvert.SerializeObject(dict);
            }
            else
            {
                response = "null";
            }
            return response;
        }
    }
}
