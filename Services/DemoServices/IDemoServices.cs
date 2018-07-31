using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DemoServices
{
    public interface IDemoServices
    {
        string GetDemoList();
        string CreateDemodetails(string details);
    }
}
