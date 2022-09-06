using ApiApplication.Constants;
using ApiApplication.Context;
using ApiApplication.Models;
using ApiApplication.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TsetProject.UsersTest
{
    public class UserServiceUnitTest
    {
        private EmpRepositories _empRepositories;
        private Users _users;
        private IEnumerable<Users> usersList;
        

        [SetUp]
        public void Setup()
        {
            var mockTest = new Mock<DbSet<Users>>();
            var mockContext = new Mock<ApiDbContext>();

            mockContext.Setup(m => m.Users).Returns(mockTest.Object);

            _empRepositories = new EmpRepositories(mockContext.Object);
            _users = UserMockObject.CreateUsers();
        }

        [Test]
        public void GetAllUsersReturnSuccess()
        {
            var data = new List<Users>
            {
                new Users {UserId = 12345,Firstname = "xwsvt",Lastname = "wfvue",Username = "xhvcv",dateofbirth = Convert.ToDateTime("1998-07-20 05:59:21.955"), employeeCode = 23774,DepartmentId = 1,Password = "dbi2eh2",CreatedBy = "dwedy",CreatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955"), updatedBy = "evfgced", updatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955") },
                new Users {UserId = 12346,Firstname = "xwsvr",Lastname = "wfvuf",Username = "cejh",dateofbirth = Convert.ToDateTime("1998-07-20 05:59:21.955"), employeeCode = 76238,DepartmentId = 2,Password = "xjvqh3",CreatedBy = "deu",CreatedDate = Convert.ToDateTime("2022-08-20 05:59:21.955"),updatedBy = "dcefty" ,updatedDate = Convert.ToDateTime("2022-07-21 05:59:21.955")},
                new Users {UserId = 12347,Firstname = "xwsvd",Lastname = "wfvus",Username = "ejhvjv",dateofbirth = Convert.ToDateTime("1998-07-20 05:59:21.955"), employeeCode = 66656,DepartmentId = 3,Password = "t3eg7b",CreatedBy = "evdu",CreatedDate = Convert.ToDateTime("2022-09-20 05:59:21.955"),updatedBy = "d3yt" ,updatedDate = Convert.ToDateTime("2022-07-22 05:59:21.955")},

            }.AsQueryable();

            var mockSet = new Mock<DbSet<Users>>();
            mockSet.As<IQueryable<Users>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Users>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Users>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Users>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);
            _empRepositories = new EmpRepositories(mockContext.Object);
            var result = _empRepositories.GetUsers();
            result.Should().HaveCountGreaterThan(2);
        }

        [Test]
        public void GetAllUsersReturnFailed()
        {
            var data = new List<Users>
            {
                
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Users>>();
            mockSet.As<IQueryable<Users>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Users>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Users>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Users>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);
            _empRepositories = new EmpRepositories(mockContext.Object);
            var result = _empRepositories.GetUsers();
            result.Should().HaveCount(0);
        }

        [Test]
        public void UpdateUserSuccesss()
        {
            var user = new Users { UserId = 12345, Firstname = "xwsvt", Lastname = "wfvue", Username = "xhvcv", dateofbirth = Convert.ToDateTime("1998-07-20 05:59:21.955"), employeeCode = 23774, DepartmentId = 1, Password = "dbi2eh2", CreatedBy = "dwedy", CreatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955"), updatedBy = "evfgced", updatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955") };
            var data = new List<Users>
            {
                new Users {UserId = 12345,Firstname = "dffg",Lastname = "vsdfv",Username = "vsfrv",dateofbirth = Convert.ToDateTime("1999-07-20 05:59:21.955"), employeeCode = 76238,DepartmentId = 2,Password = "xjvqh3",CreatedBy = "deu",CreatedDate = Convert.ToDateTime("2021-08-20 05:59:21.955"),updatedBy = "dcefty" ,updatedDate = Convert.ToDateTime("2021-07-21 05:59:21.955")},
                
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Users>>();
            mockSet.As<IQueryable<Users>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Users>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Users>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Users>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);
            mockContext.Setup(m => m.SaveChanges()).Returns(1);
            _empRepositories = new EmpRepositories(mockContext.Object);
            var result = _empRepositories.UpdateUsers(user);
            result.Result.Should().Be(null);
        }

        [Test]
        public void UpdateUserFailed()
        {
            var user = new Users { UserId = 12345, Firstname = "xwsvt", Lastname = "wfvue", Username = "xhvcv", dateofbirth = Convert.ToDateTime("1998-07-20 05:59:21.955"), employeeCode = 23774, DepartmentId = 1, Password = "dbi2eh2", CreatedBy = "dwedy", CreatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955"), updatedBy = "evfgced", updatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955") };
            var data = new List<Users>
            {

            }.AsQueryable();

            var mockSet = new Mock<DbSet<Users>>();
            mockSet.As<IQueryable<Users>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Users>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Users>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Users>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);
            mockContext.Setup(m => m.SaveChanges()).Returns(0);
            _empRepositories = new EmpRepositories(mockContext.Object);
            var result = _empRepositories.UpdateUsers(user);
            result.StatusCode.Should().Be(404);
            result.Message.Should().Be(DepConstans.UserUpdateFailed);
            result.Result.Should().BeNull();
        }

        [Test]
        public void CreateUserSuccess()
        {
            var user = new Users { UserId = 12345, Firstname = "xwsvt", Lastname = "wfvue", Username = "xhvcv", dateofbirth = Convert.ToDateTime("1998-07-20 05:59:21.955"), employeeCode = 23774, DepartmentId = 1, Password = "dbi2eh2", CreatedBy = "dwedy", CreatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955"), updatedBy = "evfgced", updatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955") };
            var data = new List<Users>
            {
                new Users {UserId = 12346,Firstname = "dffg",Lastname = "vsdfv",Username = "vsfrv",dateofbirth = Convert.ToDateTime("1999-07-20 05:59:21.955"), employeeCode = 76238,DepartmentId = 2,Password = "xjvqh3",CreatedBy = "deu",CreatedDate = Convert.ToDateTime("2021-08-20 05:59:21.955"),updatedBy = "dcefty" ,updatedDate = Convert.ToDateTime("2021-07-21 05:59:21.955")},

            }.AsQueryable();

            var mockSet = new Mock<DbSet<Users>>();
            mockSet.As<IQueryable<Users>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Users>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Users>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Users>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);
            mockContext.Setup(m => m.SaveChanges()).Returns(1);
            _empRepositories = new EmpRepositories(mockContext.Object);
            var result = _empRepositories.AddUsers(user);
            result.StatusCode.Should().Be(200);
            result.Message.Should().Be(DepConstans.UserCreatedSuccessfully);
            result.Result.Should().Be(1);
        }

        [Test]
        public void CreateUserFailed()
        {
            var user = new Users { UserId = 12345, Firstname = "xwsvt", Lastname = "wfvue", Username = "xhvcv", dateofbirth = Convert.ToDateTime("1998-07-20 05:59:21.955"), employeeCode = 23774, DepartmentId = 1, Password = "dbi2eh2", CreatedBy = "dwedy", CreatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955"), updatedBy = "evfgced", updatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955") };
            var data = new List<Users>
            {

            }.AsQueryable();

            var mockSet = new Mock<DbSet<Users>>();
            mockSet.As<IQueryable<Users>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Users>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Users>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Users>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);
            mockContext.Setup(m => m.SaveChanges()).Returns(0);
            _empRepositories = new EmpRepositories(mockContext.Object);
            var result = _empRepositories.AddUsers(user);
            result.StatusCode.Should().Be(409);
            result.Message.Should().Be(DepConstans.UserCreationFailed);
            result.Result.Should().BeNull();
        }

        [TestCase("1")]
        public void DeleteUserSuccess(int id)
        {
            var data = new List<Users>
            {
                 new Users { UserId = 1, Firstname = "xwsvt", Lastname = "wfvue", Username = "xhvcv", dateofbirth = Convert.ToDateTime("1998-07-20 05:59:21.955"), employeeCode = 23774, DepartmentId = 1, Password = "dbi2eh2", CreatedBy = "dwedy", CreatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955"), updatedBy = "evfgced", updatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955") },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Users>>();
            mockSet.As<IQueryable<Users>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Users>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Users>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Users>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            mockContext.Setup(m => m.SaveChanges()).Returns(1);

            _empRepositories = new EmpRepositories(mockContext.Object);
            var result = _empRepositories.DeleteUsers(id);
            result.StatusCode.Should().Be(200);
            result.Message.Should().Be(DepConstans.UserDeleteSuccessfully);
            result.Result.Should().Be(1);
        }

        [TestCase("1")]
        public void DeleteUserFailed(int id)
        {
            var data = new List<Users>
            {
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Users>>();
            mockSet.As<IQueryable<Users>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Users>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Users>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Users>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            mockContext.Setup(m => m.SaveChanges()).Returns(0);

            _empRepositories = new EmpRepositories(mockContext.Object);
            var result = _empRepositories.DeleteUsers(id);
            result.StatusCode.Should().Be(500);
            result.Message.Should().Be(DepConstans.UserDeleteFailed);
            result.Result.Should().Be(0);
        }

        [TestCase("1")]
        public void GetUserByIdSuccess(int id)
        {
            var data = new List<Users>
            {
                 new Users { UserId = 1, Firstname = "xwsvt", Lastname = "wfvue", Username = "xhvcv", dateofbirth = Convert.ToDateTime("1998-07-20 05:59:21.955"), employeeCode = 23774, DepartmentId = 1, Password = "dbi2eh2", CreatedBy = "dwedy", CreatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955"), updatedBy = "evfgced", updatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955") },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Users>>();
            mockSet.As<IQueryable<Users>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Users>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Users>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Users>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            mockContext.Setup(m => m.SaveChanges()).Returns(1);

            _empRepositories = new EmpRepositories(mockContext.Object);
            var result = _empRepositories.GetUsersById(id);
            result.StatusCode.Should().Be(200);
            result.Message.Should().Be(DepConstans.UserIDFound);
            result.Result.Should().NotBeNull();
        }

        [TestCase("1")]
        public void GetUserByIdFailed(int id)
        {
            var data = new List<Users>
            {
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Users>>();
            mockSet.As<IQueryable<Users>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Users>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Users>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Users>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            mockContext.Setup(m => m.SaveChanges()).Returns(0);

            _empRepositories = new EmpRepositories(mockContext.Object);
            var result = _empRepositories.GetUsersById(id);
            result.StatusCode.Should().Be(404);
            result.Message.Should().Be(DepConstans.UsersIdNotFound);
            result.Result.Should().BeNull();
        }
    }
}
