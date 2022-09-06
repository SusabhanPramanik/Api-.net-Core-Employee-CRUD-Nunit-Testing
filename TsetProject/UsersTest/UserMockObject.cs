using ApiApplication.Models;
using System;

namespace TsetProject.UsersTest
{
    public class UserMockObject
    {

        public static Users CreateUsers()
        {
            Users emp = new Users();
            emp.UserId = 2335;
            emp.Firstname = "xwsvt";
            emp.Lastname = "wfvue";
            emp.Username = "xwjdh";
            emp.dateofbirth = Convert.ToDateTime("1998-07-20 05:59:21.955");
            emp.employeeCode = 27852;
            emp.DepartmentId = 1;
            emp.Password = "dbi2eh2";
            emp.CreatedBy = "dwedy";
            emp.CreatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955");
            emp.updatedBy = "evfgced";
            emp.updatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955");

            return emp;
        }
    }
}
