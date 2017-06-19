using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Diagnostics;

namespace TestProject.PMS
{
    [TestClass]
    public class UnitTest4
    {
        [TestMethod]
        public void Linq1()
        {
               Query1();
           // Query2();

            //Query3();
          //  Query4();

            //WriteOutput();

        }

        private void Query4()
        {
           
            var Query = from e in EmployeeRepo.AllEmployees
                        select new { e.EName,
                            e.DeptID,
                            deptname = (from d in EmployeeRepo.AllDepts where d.DeptID == e.DeptID select d).First()

                        };

            foreach (var c in Query)
            {
                Debug.WriteLine("--------------------------------------------");

                Debug.WriteLine(string.Format("Dept Name - {0} {1} {2}", c.EName,c.DeptID,c.deptname.DeptName));

            }



            var Query2 = EmployeeRepo.AllEmployees
                            .Select(e => new
                            {
                                e.EName,
                                e.DeptID,
                                deptname = EmployeeRepo.AllDepts.Where(d => d.DeptID == e.DeptID).Select(d => d).First()
                            });



            foreach (var c in Query2)
            {
                Debug.WriteLine("--------------------------------------------");

                Debug.WriteLine(string.Format("Dept Name - {0} {1} {2}", c.EName, c.DeptID, c.deptname.DeptName));

            }

        }

        private void Query3()
        {
            // Left ourter join

            var Query = from d in EmployeeRepo.AllDepts
                        join e in EmployeeRepo.AllEmployees on d.DeptID equals e.DeptID into gj                      
                        select new { d.DeptName, gj };
            
            foreach (var c in Query)
            {
                Debug.WriteLine("--------------------------------------------");

                Debug.WriteLine(string.Format("Dept Name - {0}", c.DeptName));

                Debug.WriteLine("--------------------------------------------");
                foreach (var s in c.gj)
                {
                    Debug.WriteLine(string.Format("Name - {0}", s.EName));
                }
            }

            // Left ourter join

            var Query3 = EmployeeRepo.AllDepts
                            .GroupJoin(EmployeeRepo.AllEmployees, d => d.DeptID, e => e.DeptID, (d, e) => new
                            {
                                d.DeptName,
                                e
                            });
              

            foreach (var d in Query3)
            {
                Debug.WriteLine("--------------------------------------------");

                Debug.WriteLine(string.Format("Dept Name - {0}", d.DeptName));

                Debug.WriteLine("--------------------------------------------");
                foreach (var s in d.e)
                {
                    Debug.WriteLine(string.Format("Name - {0}", s.EName));
                }
            }
        }

        private void WriteOutput( )
        {
          
        }

        private void Query2()
        {
            var Query = from e in EmployeeRepo.AllEmployees
                        join d in EmployeeRepo.AllDepts on e.DeptID equals d.DeptID
                        select new { e.EName, d.DeptName };

            var Queryver2 = EmployeeRepo.AllEmployees.Join(EmployeeRepo.AllDepts,e => e.DeptID,d=> d.DeptID,(s,d) => new { s,d }   );
                        

            //var result = Query.ToList();

            //var result2 = Query.ToList();

            foreach (var c in Query.ToList())
            {
                Debug.WriteLine(string.Format("Name - {0} - {1}", c.EName, c.DeptName));
            }

            foreach (var c in Queryver2.ToList())
            {
                Debug.WriteLine(string.Format("Name - {0} - {1}", c.s.EName, c.d.DeptName));
            }


        }

        private void Query1()
        {
            // var Query = EmployeeRepo.AllEmployees.Where(e => e.EmployeeID == 1).OrderByDescending(e => e.EmployeeID);


            //var Query = (from c in EmployeeRepo.AllEmployees where c.EmployeeID == 1 orderby c.EmployeeID select c);


            var Query = from c in EmployeeRepo.AllEmployees   orderby c.EName select c;            

            foreach (var item in Query)
            {
                Debug.WriteLine("--------------------------------------------");
                Debug.WriteLine(string.Format("{0} {1} {2}", item.EName, item.EmployeeID,item.DeptID));
            }
            //.Where(e => e.EmployeeID == 1).Select(e => e);


            var Query2 = EmployeeRepo.AllEmployees.Where(e => e.EName.Contains("emp")).OrderBy(e => e.EName);

            foreach (var item in Query2)
            {
                Debug.WriteLine("--------------------------------------------");
                Debug.WriteLine(string.Format("{0} {1} {2}", item.EName, item.EmployeeID, item.DeptID));
            }


        }

    }

    public static class EmployeeRepo
    {
        public static List<Employee> AllEmployees
        {
            get
            {

                List<Employee> lstEmp = new List<Employee>() {

                new Employee { EmployeeID = 1, EName="Employee 1",DeptID =1 },
                new Employee { EmployeeID = 2, EName="Employee 2",DeptID =1 },
                new Employee { EmployeeID = 3, EName="Employee 3",DeptID =1},
                new Employee { EmployeeID = 4, EName="Employee 4",DeptID =2 },
                new Employee { EmployeeID = 5, EName="Employee 5",DeptID =2 },
                new Employee { EmployeeID = 6, EName="Employee 6",DeptID =2 }
            };

                return lstEmp;

            }
        }

        public static List<Department> AllDepts
        {
            get
            {
                List<Department> lstDept = new List<Department>() {

                new Department {DeptID= 1, DeptName ="Studio" },
                new Department {DeptID = 2, DeptName="Admin" },
                new Department { DeptID = 3, DeptName="HR" }

            };

                return lstDept;
            }

        }
    }

    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EName { get; set; }
        public int DeptID { get; set; }
    }

    public class Department
    {
        public int DeptID { get; set; }
        public string DeptName { get; set; }
    }

}
