using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao.Entities;
namespace Dao.Models.MemberModels
{
    public interface IMemberDao
    {
        int CreateMember(User member);
        int UpdateProfilePic(User member);
        int UpdateFile(User member);
        int CreateAddress(Address address);
    }
}
