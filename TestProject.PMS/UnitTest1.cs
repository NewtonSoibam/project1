using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ERP.Core.DataAccessLayer.PMS;
using ERP.Core.DataModel.PMS;
using System.Linq.Expressions;
using System.Diagnostics;
using ERP.Core.DataRepositoryLayer;
using ERP.Core.DataRepositoryLayer.PMS;
using App.DL.M1;

using App.DL.M2;
using App.Core.DataModel.M1;



namespace TestProject.PMS
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            //PMSDBContextUOW pmsDBContext = new PMSDBContextUOW();

            //ProjectClientRepository repo = new ProjectClientRepository(pmsDBContext);

            //ProjectRespository prepo = new ProjectRespository(pmsDBContext);


           M1DBContext dbcontext = new M1DBContext();

           Customer c2 = new Customer();
           c2.LastName = "Newton";
           c2.FirstName = "Singh";
           c2.Title = "Mr";
           c2.CreatedBy = 1;
           c2.CreatedOn = DateTime.Now;

           dbcontext.Customers.Add(c2);
           dbcontext.SaveChanges();

           var query =  dbcontext.Customers;

           foreach (var c in query.ToList())
           {
               Debug.WriteLine(string.Format("Name - {0} - {1}", c.FirstName, c.LastName));
           }

            //var query = pmsDBContext.ProjectClients
            //           .Select(c => c)
            //           .OrderBy(c => c.ProjClient);

            //var resultSet = query.ToList();

            //var query = prepo.All.Take(2);

            //foreach (var c in query.ToList())
            //{
            //    Debug.WriteLine(string.Format("Name - {0} - {1}", c.ProjectName,c.ProjectStatus));
            //}

            ForConnection();
        }


        [TestMethod]
        public void TestMethod2()
        {

            PMSDBContextUOW pmsDBContext = new PMSDBContextUOW();
            ProjectClientRepository repo = new ProjectClientRepository(pmsDBContext);
            ProjectRespository prepo = new ProjectRespository(pmsDBContext);

            var query = repo.All
                       .Select(c => c)
                       .OrderBy(c => c.ProjClient);

            var resultSet = query.ToList();

          //  var query = prepo.All.Take(2);

            foreach (var c in query.ToList())
            {
                Debug.WriteLine(string.Format("Name - {0} - {1}", c.ProjClient, c.CreatedOn));
            }
        }




        public void ForConnection()
        {
            string connectionString = "VWv0IiOcwCjxAMyG8uOgP61sbtN3tdhSzcbWV+PYdySj+cqy9eClWmFO+5adLr5N524YwI2Q2iIS1ljuhGiIQU3mn6oHPJ/XkjzqeGsO40Yx+YStFo2d+2KdJMAtq85G96xKC/G5Qrvcdla6h8O+bXxvUcSahxHto3aet68nbJKB40fk1vYbGOqCxasTrjrwNzcpdiChEaSJNwUr+3aaCA==";
        //    string constring = "data source=192.168.0.5;initial catalog=ERPDB;persist security info=True;user id=erpappuser;password=erp;multipleactiveresultsets=True;App=EntityFramework";
            string dconnectionString = ERP.Core.DataAccessLayer.PMS.CryptographyForDataAccess.DecryptForSettings(connectionString, "ANQAMRHDEDRF");

            string connectionString2 = "VWv0IiOcwCjxAMyG8uOgPxNPkVc0fLqr+wC18vkV8tLXUaX1GvUJinvQUzUHbQXnfSMUagRt3JzqZdgejtiDjOis4b5XMsKHvPbOXRK61Ti3OMA4L5JERusM4Jzuwx9dIc5CkmLGJVcFIUvVxPaG1+Zs09Et/vd8kOL1meJgni1tQ+ifPZSl4yR8QVlP+iIaUCq88+j3i/OeoycZEKD2IA==";
               
            string dconnectionString2 = ERP.Core.DataAccessLayer.PMS.CryptographyForDataAccess.DecryptForSettings(connectionString2, "ANQAMRHDEDRF");

        }
    }
}
