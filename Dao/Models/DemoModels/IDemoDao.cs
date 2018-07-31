using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dao.Entities;
namespace Dao.Models.DemoModels
{
  public interface IDemoDao
    {
     IEnumerable<Demo> GetDemoList();
      Boolean CreateDemo(Demo demo);
    }
}
