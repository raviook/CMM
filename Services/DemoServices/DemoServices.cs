using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Dao.Models.DemoModels;
namespace Services.DemoServices
{
   public  class DemoServices : IDemoServices
    {
        private readonly IDemoDao _demoDal;
        public DemoServices(IDemoDao demoDal)
        {
            _demoDal = demoDal;
        }
        public string CreateDemodetails(string details)
        {
            throw new NotImplementedException();
        }

        public string GetDemoList()
        {
            var demoList = _demoDal.GetDemoList();
            string result = JsonConvert.SerializeObject(demoList);
            return result;
        }
    }
}
