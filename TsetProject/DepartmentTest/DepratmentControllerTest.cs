using ApiApplication.Constants;
using ApiApplication.Context;
using ApiApplication.Controllers;
using ApiApplication.Models;
using ApiApplication.Repositories;
using ApiApplication.Repositories.Contracts;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TsetProject.DepartmetTest;

namespace TsetProject.DepartmentTest
{
    public class DepratmentControllerTest
    {
        private Mock<IDepRepositories> _depService;
        private DepartmentController _departmentController;
        private Mock<Department> _department;
        private Department _depDto;

        [SetUp]
        public void Setup()
        {
            var mockSet = new Mock<DbSet<Department>>();

            var mockContext = new Mock<ApiDbContext>();

            _depService = new Mock<IDepRepositories>();
            _departmentController = new DepartmentController(_depService.Object);
        }


        [Test]
        public void GetDepartment_ReturnSuccess()
        {
            //Arrange
            IEnumerable<Department> list = new List<Department>
            {
                 new Department {DepartmentId =1,  DepartmentaName = "testDepartment 1" },
                new Department {DepartmentId =2,  DepartmentaName = "testDepartment 2" },
                new Department {DepartmentId =3,  DepartmentaName = "testDepartment 3" },

            };

            //Act
            _depService.Setup(p => p.GetDepartments()).Returns(list);
          
            //Result
            var result = _departmentController.Get();
            (result as ApiResponse).StatusCode.Should().Be(200);
            (result as ApiResponse).StatusCode.Should().BeGreaterThan(2);
            Assert.IsTrue(result.Result != null);
        }

        [Test]
        public void GetDepartment_ReturnFailed()
        {
            //Arrange
            IEnumerable<Department> list = new List<Department>();
            list = null;

            //Act
            _depService.Setup(p => p.GetDepartments()).Returns(list);

            //Result
            var result = _departmentController.Get();
            (result as ApiResponse).StatusCode.Should().Be(404);
            (result as ApiResponse).StatusCode.Should().BeGreaterThanOrEqualTo(0);
            Assert.IsTrue(result.Result == null);
        }



        [Test]
        public void CreateDepartment_ReturnSuccess()
        {

            Department dep = new Department { DepartmentId = 2, DepartmentaName = "TestDepartment2" };
            //Arrange
            ApiResponse apiResponse = new ApiResponse((int)HttpStatusCode.OK, DepConstans.DepCreatedSuccessfully, 1);
            //Mock<Department>  _dep = new Mock<Department>();
            _depService.Setup(x => x.AddDepartment(It.IsAny<Department>())).Returns(apiResponse);
            //var mockContext = new Mock<EmpDbContext>();
            //Act
            var result = _departmentController.AddDepartment(dep);

            //result
            Assert.IsTrue(result.StatusCode == (int)HttpStatusCode.OK);
            (result as ApiResponse).StatusCode.Should().Be(200);
            (result as ApiResponse).Result.Should().NotBeNull();

        }

        [Test]
        public void CreateDepartment_ReturnFailed()
        {

            Department dep = new Department {  };

            //Arrange
            ApiResponse apiResponse = new ApiResponse((int)HttpStatusCode.NotFound, DepConstans.DepCreationFailed, 0);
            //Mock<Department> _dep = new Mock<Department>();
            _depService.Setup(x => x.AddDepartment(It.IsAny<Department>())).Returns(apiResponse);
            //var mockContext = new Mock<EmpDbContext>();

            //_depService.Setup(m => m.AddDepartment(dep)).Returns(apiResponse);
            //Act
           // mockContext.Setup(m => m.SaveChanges()).Returns(0);
            var result =_departmentController.AddDepartment(dep);

            //result

            Assert.IsFalse(result.StatusCode == (int)HttpStatusCode.NotFound);
            (result as ApiResponse).StatusCode.Should().Be(409);
            (result as ApiResponse).Result.Should().Be(null);

        }

        [Test]
        public void UpdateDepartment_ReturnSuccess()
        {
            Department dep = new Department { DepartmentId = 1, DepartmentaName = "TestDepartment" };
            ApiResponse apiResponse = new ApiResponse((int)HttpStatusCode.OK, DepConstans.DepUpdateSuccessfully, 1);
            Mock<Department> _dep = new Mock<Department>();
            _depService.Setup(x => x.UpdateDepartment(It.IsAny<Department>())).Returns(apiResponse);
            
            var result = _departmentController.UpdateDepartment(dep);

            Assert.IsTrue(result.StatusCode == (int)HttpStatusCode.OK);
            (result as ApiResponse).StatusCode.Should().Be(200);
            (result as ApiResponse).Result.Should().NotBeNull();
            (result as ApiResponse).Result.Should().Be(1);

        }

        [Test]
        public void UpdateDepartment_ReturnFailed()
        {
            Department dep = new Department {  };
            ApiResponse apiResponse = new ApiResponse((int)HttpStatusCode.NotFound, DepConstans.DepUpdateFailed, 0);
           // Mock<Department> _dep = new Mock<Department>();
            _depService.Setup(x => x.UpdateDepartment(It.IsAny<Department>())).Returns(apiResponse);

            var result = _departmentController.UpdateDepartment(dep);

            Assert.IsFalse(result.StatusCode == (int)HttpStatusCode.NotFound);
            (result as ApiResponse).StatusCode.Should().Be(409);
            (result as ApiResponse).Result.Should().BeNull();


        }

        [Test]
        public void GetDepartmentById_ReturnSuccess()
        {
                _depDto = DepartmentMockObject.CreateDepartment();
                ApiResponse apiResponse = new ApiResponse((int)HttpStatusCode.OK, DepConstans.DepIDFound, _depDto);

                _depService.Setup(p => p.GetDepartmentsById(It.IsAny<int>())).Returns(apiResponse);

                var result = _departmentController.GetDepartmentsById(1);

                var okResult = result as ApiResponse;
                Assert.IsTrue(okResult.StatusCode == (int)HttpStatusCode.OK);
                Assert.IsTrue(okResult.Result != null);
                (result as ApiResponse).Result.Should().NotBeNull();
        }

        [Test]
        public void GetDepartmentById_RetuentFailed()
        {
            _depDto = null;
            ApiResponse apiResponse = new ApiResponse((int)HttpStatusCode.NotFound, DepConstans.DepIDnotFoud, _depDto);

            _depService.Setup(p => p.GetDepartmentsById(It.IsAny<int>())).Returns(apiResponse);

            var result = _departmentController.GetDepartmentsById(1);

            var okResult = result as ApiResponse;
            Assert.IsTrue(okResult.StatusCode == (int)HttpStatusCode.NotFound);
            Assert.IsTrue(okResult.Result == null);

        }


        [Test]
        public void DeleteDepratment_ReturnSuccesss()
        {
            Department deprequest = new Department { DepartmentId = 1, DepartmentaName ="Test" };

            ApiResponse apiResponse = new ApiResponse((int)HttpStatusCode.OK, DepConstans.DepDeleteSuccessfully, 1);

            _depService.Setup(p => p.DeleteDepartment(deprequest.DepartmentId)).Returns(apiResponse);

            var result = _departmentController.DeleteDepartment(1);

            var StatusCode = result as ApiResponse;
            (result as ApiResponse).StatusCode.Should().Be(200);
            Assert.IsTrue(StatusCode.StatusCode == (int)HttpStatusCode.OK);
            (result as ApiResponse).Result.Should().Be(1);

        }

        [Test]
        public void DeleteDepratment_ReturnFailed()
        {
            Department deprequest = new Department { };

            ApiResponse apiResponse = new ApiResponse((int)HttpStatusCode.NotFound, DepConstans.DepDeleteFailed, 0);

            _depService.Setup(p => p.DeleteDepartment(deprequest.DepartmentId)).Returns(apiResponse);

            var result = _departmentController.DeleteDepartment(0);

            var StatusCode = result as ApiResponse;
            (result as ApiResponse).StatusCode.Should().Be(409);
            Assert.IsFalse(StatusCode.StatusCode == (int)HttpStatusCode.NotFound);
            (result as ApiResponse).Result.Should().BeNull();
        }

    }
}
