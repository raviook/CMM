using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao.Models.MemberModels;
using Newtonsoft.Json;
using Dao.Entities;

namespace Services.MemberServices
{
   public  class MemberServices: IMemberServices
    {
        private readonly IMemberDao _memberDao;

        public MemberServices(IMemberDao memberDao)
        {
            _memberDao = memberDao;
        }
        public string CreateMember(string memberDetails)
        {
            Dictionary<string, string> dictFormData = new Dictionary<string, string>();
            dictFormData = JsonConvert.DeserializeObject<Dictionary<string, string>>(memberDetails);
            User user = new User();
            Address address = new Address();
            address.Address1 = dictFormData["address"];
            address.City = dictFormData["city"];
            address.StateProvince = dictFormData["stateProvince"];
            address.Country = dictFormData["country"];
            address.ZipPostalCode = dictFormData["zipPostalCode"];
            int addressId = _memberDao.CreateAddress(address);
            user.AddressId = addressId;
            user.FirstName= dictFormData["firstName"];
            user.LastName= dictFormData["lastName"];
            user.Date = DateTime.Now;
            user.EmailId = dictFormData["emailId"];
            user.MembershipId = dictFormData["membershipId"];
            user.MembershipType = dictFormData["membershipType"];
            user.MobileNumber = dictFormData["mobileNumber"].ToString();
            user.ShowOnHomePage = dictFormData["showOnHomePage"];
            int memberId =_memberDao.CreateMember(user);
            string response = memberId.ToString();
            return response;
        }

        public string UpdateProfilePic(string picUrl,string Id)
        {
            User user = new User();
            user.ProfilePicUrl = picUrl;
            user.UserId = Int32.Parse(Id);
           var memberId= _memberDao.UpdateProfilePic(user);
            return memberId.ToString();
        }

        public string UploadFile(string file, string Id)
        {
            User user = new User();
            user.FileUrl = file;
            user.UserId = Int32.Parse(Id);
            var memberId = _memberDao.UpdateFile(user);
            return memberId.ToString();
        }
    }
}
