using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao.Entities;
namespace Dao.Models.MemberModels
{
    public class MemberDao:IMemberDao
    {
        private readonly CMMdbEntities _connection;
        public MemberDao(CMMdbEntities connection)
        {
            _connection = connection;
        }
  
       public  int CreateMember(User member)
        {
            _connection.Users.Add(member);
                _connection.SaveChanges();           
            return member.UserId;
        }
        public int UpdateProfilePic(User member)
        {
          var tempMember=  _connection.Users.Where(m => m.UserId == member.UserId).FirstOrDefault();
            tempMember.ProfilePicUrl = member.ProfilePicUrl;
            _connection.SaveChanges();           
            return member.UserId;

        }
        public int UpdateFile(User member)
        {
            var tempMember = _connection.Users.Where(m => m.UserId == member.UserId).FirstOrDefault();
            tempMember.FileUrl = member.FileUrl;
            _connection.SaveChanges();
            return member.UserId;

        }

        public int CreateAddress(Address address)
        {
           _connection.Addresses.Add(address);
            _connection.SaveChanges();
            return address.AddressId;
        }
    }
}
