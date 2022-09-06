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

namespace TsetProject.RoleTest
{
    public class RoleControllerTest
    {
        private Mock<IRoleRepositories> _roleService;
        private RolesController _roleController;
        private Mock<Roles> _roles;
        private Roles _RoleDto;

        [SetUp]
        public void Setup()
        {
            var mockSet = new Mock<DbSet<Roles>>();

            var mockContext = new Mock<ApiDbContext>();

            _roleService = new Mock<IRoleRepositories>();
            _roleController = new RolesController(_roleService.Object);
        }

        [Test]
        public void GetRoles_ReturnSuccess()
        {
            //Arrange
            IEnumerable<Roles> list = new List<Roles>
            {
                 new Roles {RoleId =1,  RoleName = "testRoles 1" },
                new Roles {RoleId =2,  RoleName = "testRoles 2" },
                new Roles {RoleId =3,  RoleName = "testRoles 3" },

            };

            //Act
            _roleService.Setup(p => p.GetRoles()).Returns(list);

            //Result
            var result = _roleController.Get();
            (result as ApiResponse).StatusCode.Should().Be(200);
            (result as ApiResponse).StatusCode.Should().BeGreaterThan(2);
            Assert.IsTrue(result.Result != null);
        }

        [Test]
        public void GetRoles_ReturnFailed()
        {
            //Arrange
            IEnumerable<Roles> list = new List<Roles>();
            list = null;

            //Act
            _roleService.Setup(p => p.GetRoles()).Returns(list);

            //Result
            var result = _roleController.Get();
            (result as ApiResponse).StatusCode.Should().Be(404);
            (result as ApiResponse).StatusCode.Should().BeGreaterThanOrEqualTo(0);
            Assert.IsTrue(result.Result == null);
        }

        [Test]
        public void CreateRoles_ReturnSuccess()
        {

            Roles dep = new Roles { RoleId = 2, RoleName = "TestRoles2" };
            //Arrange
            ApiResponse apiResponse = new ApiResponse((int)HttpStatusCode.OK, DepConstans.RoleCreatedSuccessfully, 1);
            Mock<Roles> _dep = new Mock<Roles>();
            _roleService.Setup(x => x.AddRoles(It.IsAny<Roles>())).Returns(apiResponse);
            var mockContext = new Mock<ApiDbContext>();
            //Act
            var result = _roleController.AddRoles(dep);

            //result
            Assert.IsTrue(result.StatusCode == (int)HttpStatusCode.OK);
            (result as ApiResponse).StatusCode.Should().Be(200);
            (result as ApiResponse).Result.Should().NotBeNull();

        }

        [Test]
        public void CreateRoles_ReturnFailed()
        {

            Roles dep = new Roles { };

            //Arrange
            ApiResponse apiResponse = new ApiResponse((int)HttpStatusCode.NotFound, DepConstans.RoleCreationFailed, 0);
            Mock<Roles> _dep = new Mock<Roles>();
            _roleService.Setup(x => x.AddRoles(It.IsAny<Roles>())).Returns(apiResponse);
            var mockContext = new Mock<ApiDbContext>();

            //_depService.Setup(m => m.AddDepartment(dep)).Returns(apiResponse);
            //Act
            mockContext.Setup(m => m.SaveChanges()).Returns(0);
            var result = _roleController.AddRoles(dep);

            //result

            Assert.IsFalse(result.StatusCode == (int)HttpStatusCode.OK);
            (result as ApiResponse).StatusCode.Should().Be(409);
            (result as ApiResponse).Result.Should().Be(null);

        }

        [Test]
        public void UpdateUsers_ReturnSuccess()
        {
            Roles dep = new Roles { RoleId = 1, RoleName = "TestRole" };
            ApiResponse apiResponse = new ApiResponse((int)HttpStatusCode.OK, DepConstans.RoleUpdateSuccessfully, 1);
            Mock<Roles> _dep = new Mock<Roles>();
            _roleService.Setup(x => x.UpdateRoles(It.IsAny<Roles>())).Returns(apiResponse);

            var result = _roleController.UpdateRoles(dep);

            Assert.IsTrue(result.StatusCode == (int)HttpStatusCode.OK);
            (result as ApiResponse).StatusCode.Should().Be(200);
            (result as ApiResponse).Result.Should().NotBeNull();
            (result as ApiResponse).Result.Should().Be(1);

        }

        [Test]
        public void UpdateUsers_ReturnFailed()
        {
            Roles dep = new Roles { };
            ApiResponse apiResponse = new ApiResponse((int)HttpStatusCode.NotFound, DepConstans.UserUpdateFailed, 0);
            Mock<Roles> _dep = new Mock<Roles>();
            _roleService.Setup(x => x.UpdateRoles(It.IsAny<Roles>())).Returns(apiResponse);

            var result = _roleController.UpdateRoles(dep);

            Assert.IsFalse(result.StatusCode == (int)HttpStatusCode.OK);
            (result as ApiResponse).StatusCode.Should().Be(409);
            (result as ApiResponse).Result.Should().BeNull();


        }

        [Test]
        public void GetUsersById_ReturnSuccess()
        {
            {
                // _depDto = DepartmentMockObject.CerateDepartment();
                Roles dep = new Roles { RoleId = 1, RoleName = "TestRole" };
                ApiResponse apiResponse = new ApiResponse((int)HttpStatusCode.OK, DepConstans.RoleIDFound, 1);

                _roleService.Setup(p => p.GetRolesById(It.IsAny<int>())).Returns(apiResponse);

                var result = _roleController.GetRolesById(1);

                var okResult = result as ApiResponse;
                Assert.IsTrue(okResult.StatusCode == (int)HttpStatusCode.OK);
                Assert.IsTrue(okResult.Result != null);
                (result as ApiResponse).Result.Should().Be(1);

            }
        }

        [Test]
        public void GetUsersById_RetuentFailed()
        {
            Roles dep = new Roles();
            dep = null;
            ApiResponse apiResponse = new ApiResponse((int)HttpStatusCode.NotFound, DepConstans.RoleIdNotFound, 0);

            _roleService.Setup(p => p.GetRolesById(It.IsAny<int>())).Returns(apiResponse);

            var result = _roleController.GetRolesById(0);

            var okResult = result as ApiResponse;
            Assert.IsTrue(okResult.StatusCode == (int)HttpStatusCode.NotFound);
            Assert.IsTrue(okResult.Result == null);

        }


        [Test]
        public void DeleteUsers_ReturnSuccesss()
        {
            Roles dep = new Roles { RoleId = 1, RoleName = "TestRole" };

            ApiResponse apiResponse = new ApiResponse((int)HttpStatusCode.OK, DepConstans.RoleDeleteSuccessfully, 1);

            _roleService.Setup(p => p.DeleteRoles(dep.RoleId)).Returns(apiResponse);

            var result = _roleController.DeleteRoles(1);

            var StatusCode = result as ApiResponse;
            (result as ApiResponse).StatusCode.Should().Be(200);
            Assert.IsTrue(StatusCode.StatusCode == (int)HttpStatusCode.OK);
            (result as ApiResponse).Result.Should().Be(1);

        }

        [Test]
        public void DeleteUsers_ReturnFailed()
        {
            Roles dep = new Roles { };

            ApiResponse apiResponse = new ApiResponse((int)HttpStatusCode.NotFound, DepConstans.UserDeleteFailed, 0);

            _roleService.Setup(p => p.DeleteRoles(dep.RoleId)).Returns(apiResponse);

            var result = _roleController.DeleteRoles(0);

            var StatusCode = result as ApiResponse;
            (result as ApiResponse).StatusCode.Should().Be(409);
            Assert.IsFalse(StatusCode.StatusCode == (int)HttpStatusCode.NotFound);
            (result as ApiResponse).Result.Should().BeNull();
        }

    }
}

