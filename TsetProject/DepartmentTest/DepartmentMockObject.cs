using ApiApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TsetProject.DepartmetTest
{
    public class DepartmentMockObject
    {
        public static Department CreateDepartment()
        {
            Department dep = new Department();
            dep.DepartmentId = 1;
            dep.DepartmentaName = "TestDepartment";

            return dep;
        }

        public static List<Department> GetDepartmentList()
        {
            List<Department> depList = new List<Department>();

            Department dep1 = new Department();
            dep1.DepartmentId = 1;
            dep1.DepartmentaName = "testDepartment";

            Department dep2 = new Department();
            dep2.DepartmentId = 1;
            dep2.DepartmentaName = "testDepartment";

            depList.Add(dep1);
            depList.Add(dep2);
            return depList;
        }

        public static Department UpdateDepartment()
        {
            Department dep1 = new Department();
            dep1.DepartmentId = 2;
            dep1.DepartmentaName = "testDepartment";
            return dep1;
        }

        public static Department DeleteDepartment()
        {
            Department dep1 = new Department();
            dep1.DepartmentId = 2;
            dep1.DepartmentaName = "cehg";
            return dep1;
        }

    }
}
