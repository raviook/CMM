using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.MemberServices
{
   public  interface IMemberServices
    {
        string CreateMember(string memberDetails);
        string UpdateProfilePic(string picUrl,string Id);
        string UploadFile(string file, string Id);
    }
}
