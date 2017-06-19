using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.DataRepositoryL.M1;
using System.Diagnostics;

namespace TestProject.PMS
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {

            M1DBContextUOW dbContext = new M1DBContextUOW();

            var customerRepo = new CustomerRepository(dbContext);

            var query = customerRepo.All.Take(2);

            foreach (var c in query.ToList())
            {
                Debug.WriteLine(string.Format("Name - {0} - {1}", c.FirstName, c.LastName));
            }          
            
        }
    }
}
