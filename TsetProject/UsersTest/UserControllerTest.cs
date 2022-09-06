using ApiApplication.Constants;
using ApiApplication.Context;
using ApiApplication.Controllers;
using ApiApplication.Models;
using ApiApplication.Repositories.Contracts;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TsetProject.UsersTest
{
    public class UserControllerTest
    {
        private Mock<IEmpRepositories> _UserService;
        private UsersController _usersController;
        private Mock<Users> _users;
        private Users _usersDto;

        [SetUp]
        public void Setup()
        {
            var mockSet = new Mock<DbSet<Users>>();
            var mockContext = new Mock<ApiDbContext>();

            _UserService = new Mock<IEmpRepositories>();
            _usersController = new UsersController(_UserService.Object);
        }


        [Test]
        public void GetUsers_ReturnSuccess()
        {
            IEnumerable<Users> List = new List<Users>
            {
                new Users {UserId = 12345,Firstname = "xwsvt",Lastname = "wfvue",Username = "xhvcv",dateofbirth = Convert.ToDateTime("1998-07-20 05:59:21.955"), employeeCode = 23774,DepartmentId = 1,Password = "dbi2eh2",CreatedBy = "dwedy",CreatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955"), updatedBy = "evfgced", updatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955") },
                new Users {UserId = 12346,Firstname = "xwsvr",Lastname = "wfvuf",Username = "cejh",dateofbirth = Convert.ToDateTime("1998-07-20 05:59:21.955"), employeeCode = 76238,DepartmentId = 2,Password = "xjvqh3",CreatedBy = "deu",CreatedDate = Convert.ToDateTime("2022-08-20 05:59:21.955"),updatedBy = "dcefty" ,updatedDate = Convert.ToDateTime("2022-07-21 05:59:21.955")},
                new Users {UserId = 12347,Firstname = "xwsvd",Lastname = "wfvus",Username = "ejhvjv",dateofbirth = Convert.ToDateTime("1998-07-20 05:59:21.955"), employeeCode = 66656,DepartmentId = 3,Password = "t3eg7b",CreatedBy = "evdu",CreatedDate = Convert.ToDateTime("2022-09-20 05:59:21.955"),updatedBy = "d3yt" ,updatedDate = Convert.ToDateTime("2022-07-22 05:59:21.955")},

            };

            _UserService.Setup(p => p.GetUsers()).Returns(List);

            var result = _usersController.Get();
            (result as ApiResponse).StatusCode.Should().Be(200);
            (result as ApiResponse).StatusCode.Should().BeGreaterThan(2);
            Assert.IsTrue(result.Result != null);
        }

        [Test]
        public void GetUsers_ReturnFailed()
        {
            IEnumerable<Users> List = new List<Users>();
            List = null;

            _UserService.Setup(p => p.GetUsers()).Returns(List);

            var result = _usersController.Get();
            (result as ApiResponse).StatusCode.Should().Be(404);
            (result as ApiResponse).StatusCode.Should().BeGreaterThanOrEqualTo(0);
            Assert.IsTrue(result.Result == null);
        }

        [Test]
        public void CreateUser_ReturnSuccess()
        {

            var user = new Users { UserId = 12345, Firstname = "xwsvt", Lastname = "wfvue", Username = "xhvcv", dateofbirth = Convert.ToDateTime("1998-07-20 05:59:21.955"), employeeCode = 23774, DepartmentId = 1, Password = "dbi2eh2", CreatedBy = "dwedy", CreatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955"), updatedBy = "evfgced", updatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955") };
            //Arrange
            ApiResponse apiResponse = new ApiResponse((int)HttpStatusCode.OK, DepConstans.DepCreatedSuccessfully, 1);
            Mock<Users> _dep = new Mock<Users>();
            _UserService.Setup(x => x.AddUsers(It.IsAny<Users>())).Returns(apiResponse);
            var mockContext = new Mock<ApiDbContext>();
            //Act
            var result = _usersController.AddUsers(user);

            //result
            Assert.IsTrue(result.StatusCode == (int)HttpStatusCode.OK);
            (result as ApiResponse).StatusCode.Should().Be(200);
            (result as ApiResponse).Result.Should().NotBeNull();

        }

        [Test]
        public void CreateUser_ReturnFailed()
        {

            var user = new Users();
            user = null;
            //Arrange
            ApiResponse apiResponse = new ApiResponse((int)HttpStatusCode.NotFound, DepConstans.UserCreationFailed, 0);
            Mock<Users> _dep = new Mock<Users>();
            _UserService.Setup(x => x.AddUsers(It.IsAny<Users>())).Returns(apiResponse);
            var mockContext = new Mock<ApiDbContext>();
            //Act
            var result = _usersController.AddUsers(user);

            //result
            Assert.IsFalse(result.StatusCode == (int)HttpStatusCode.OK);
            (result as ApiResponse).StatusCode.Should().Be(404);
            (result as ApiResponse).Result.Should().Be(null);

        }

        [Test]
        public void UpdateUsers_ReturnSuccess()
        {

            var user = new Users { UserId = 12345, Firstname = "xwsvt", Lastname = "wfvue", Username = "xhvcv", dateofbirth = Convert.ToDateTime("1998-07-20 05:59:21.955"), employeeCode = 23774, DepartmentId = 1, Password = "dbi2eh2", CreatedBy = "dwedy", CreatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955"), updatedBy = "evfgced", updatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955") };
            ApiResponse apiResponse = new ApiResponse((int)HttpStatusCode.OK, DepConstans.UserUpdateSuccessfully, 1);
            Mock<Users> _dep = new Mock<Users>();
            _UserService.Setup(x => x.UpdateUsers(It.IsAny<Users>())).Returns(apiResponse);

            var result = _usersController.UpdateUsers(user);

            Assert.IsTrue(result.StatusCode == (int)HttpStatusCode.OK);
            (result as ApiResponse).StatusCode.Should().Be(200);
            (result as ApiResponse).Result.Should().NotBeNull();
            (result as ApiResponse).Result.Should().Be(1); 

        }

        [Test]
        public void UpdateUsers_ReturnFailed()
        {

            var user = new Users { };
            ApiResponse apiResponse = new ApiResponse((int)HttpStatusCode.NotFound, DepConstans.UserMappingUpdateFailed, 0);
            Mock<Users> _dep = new Mock<Users>();
            _UserService.Setup(x => x.UpdateUsers(It.IsAny<Users>())).Returns(apiResponse);

            var result = _usersController.UpdateUsers(user);

            Assert.IsFalse(result.StatusCode == (int)HttpStatusCode.OK);
            (result as ApiResponse).StatusCode.Should().Be(404);
            (result as ApiResponse).Result.Should().BeNull();

        }

        [Test]
        public void GetUserById_ReturnSuccess()
        {
            {
                _usersDto = UserMockObject.CreateUsers();
                ApiResponse apiResponse = new ApiResponse((int)HttpStatusCode.OK, DepConstans.UserIDFound, 1);

                _UserService.Setup(p => p.GetUsersById(It.IsAny<int>())).Returns(apiResponse);

                var result = _usersController.GetUsersById(1);

                var okResult = result as ApiResponse;
                Assert.IsTrue(okResult.StatusCode == (int)HttpStatusCode.OK);
                Assert.IsTrue(okResult.Result != null);
                (result as ApiResponse).Result.Should().Be(1);

            }
        }

        [Test]
        public void GetUserById_RetuentFailed()
        {
            _usersDto = null;
            ApiResponse apiResponse = new ApiResponse((int)HttpStatusCode.NotFound, DepConstans.UsersIdNotFound, 0);

            _UserService.Setup(p => p.GetUsersById(It.IsAny<int>())).Returns(apiResponse);

            var result = _usersController.GetUsersById(0);

            var okResult = result as ApiResponse;
            Assert.IsTrue(okResult.StatusCode == (int)HttpStatusCode.NotFound);
            Assert.IsTrue(okResult.Result == null);

        }


        [Test]
        public void DeleteUser_ReturnSuccesss()
        {
            // Department deprequest = new Department { DepartmentId = 1, DepartmentaName = "Test" };
            _usersDto = UserMockObject.CreateUsers();

            ApiResponse apiResponse = new ApiResponse((int)HttpStatusCode.OK, DepConstans.UserDeleteSuccessfully, 1);

            _UserService.Setup(p => p.DeleteUsers(_usersDto.DepartmentId)).Returns(apiResponse);

            var result = _usersController.DeleteUsers(1);

            var StatusCode = result as ApiResponse;
            (result as ApiResponse).StatusCode.Should().Be(200);
            Assert.IsTrue(StatusCode.StatusCode == (int)HttpStatusCode.OK);
            (result as ApiResponse).Result.Should().Be(1);

        }

        [Test]
        public void DeleteDepratment_ReturnFailed()
        {
            Users userrequest = new Users { };

            ApiResponse apiResponse = new ApiResponse((int)HttpStatusCode.NotFound, DepConstans.UserDeleteFailed, 0);

            _UserService.Setup(p => p.DeleteUsers(userrequest.UserId)).Returns(apiResponse);

            var result = _usersController.DeleteUsers(0);

            var StatusCode = result as ApiResponse;
            (result as ApiResponse).StatusCode.Should().Be(404);
            Assert.IsTrue(StatusCode.StatusCode == (int)HttpStatusCode.NotFound);
            (result as ApiResponse).Result.Should().BeNull();
        }
    }
}
