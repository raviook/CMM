using System;
using System.Collections.Generic;
using System.Linq;
using Dao.Entities;
namespace Dao.Models.DemoModels
{
    public class DemoDao : IDemoDao
    {
        private readonly CMMdbEntities _connection;
        public DemoDao(CMMdbEntities connection)
        {
            _connection = connection;
        }
       public  bool CreateDemo(Demo demo)
        {
            bool result=false;
            try
            {
                _connection.Demoes.Add(demo);
                _connection.SaveChanges();
                result = true;
            }
            catch(Exception ex)
            {
               
            }

                return result;

        }
       public  IEnumerable<Demo> GetDemoList()
        {
            var result = _connection.Demoes.ToList();
            return result;
        }
    }
}
