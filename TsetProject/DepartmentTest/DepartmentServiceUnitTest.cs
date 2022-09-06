using ApiApplication.Constants;
using ApiApplication.Context;
using ApiApplication.Models;
using ApiApplication.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TsetProject.DepartmetTest
{
    public class DepartmentServiceUnitTest
    {
        private DepRepositories _depRepositories;
        private Department department;
        private IEnumerable<Department> departmentList;




        [SetUp]
        public void Setup()
        {
            var mockSet = new Mock<DbSet<Department>>();

            var mockContext = new Mock<ApiDbContext>();

            mockContext.Setup(m => m.Departments).Returns(mockSet.Object);

            _depRepositories = new DepRepositories(mockContext.Object);
        }


        [Test]
        public void GetAllDepartmentReturnSuccess()
        {
            var data = new List<Department>
            {
                new Department {DepartmentId =1,  DepartmentaName = "testDepartment 1" },
                new Department {DepartmentId =2, DepartmentaName = "testDepartment 2" },
                new Department {DepartmentId =3, DepartmentaName = "testDepartment 3" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Department>>();
            mockSet.As<IQueryable<Department>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Department>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Department>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Department>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();

            mockContext.Setup(m => m.Departments).Returns(mockSet.Object);

            _depRepositories = new DepRepositories(mockContext.Object);

            var result = _depRepositories.GetDepartments();

            result.Should().HaveCountGreaterThan(2);
        }

        [Test]
        public void GetAllDepartmnetReturnFailed()
        {
            var data = new List<Department>
            {
                
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Department>>();
            mockSet.As<IQueryable<Department>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Department>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Department>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Department>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();

            mockContext.Setup(m => m.Departments).Returns(mockSet.Object);

            _depRepositories = new DepRepositories(mockContext.Object);

            var result = _depRepositories.GetDepartments();

            result.Should().HaveCount(0);
        }

        [Test]
        public void UpdateDepartmentSuccess()
        {
            Department dep = new Department { DepartmentId = 1, DepartmentaName = "JAVA" };
           
            var data = new List<Department>
            {
                 new Department {DepartmentId =1,  DepartmentaName = "testDepartment 1" },
            }.AsQueryable();
            
            var mockSet = new Mock<DbSet<Department>>();
            mockSet.As<IQueryable<Department>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Department>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Department>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Department>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();
            mockContext.Setup(m => m.Departments).Returns(mockSet.Object);
            mockContext.Setup(x => x.SaveChanges()).Returns(1);

            _depRepositories = new DepRepositories(mockContext.Object);
            var result = _depRepositories.UpdateDepartment(dep);
            result.Result.Should().Be(1);
        }

        [Test]
        public void UpdateDepartmentDublicateFailed()
        {
            Department dep = new Department { DepartmentId = 1, DepartmentaName = "JAVA" };

            var data = new List<Department>
            {
                 new Department {DepartmentId =1,  DepartmentaName = "JAVA" },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Department>>();
            mockSet.As<IQueryable<Department>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Department>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Department>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Department>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();
            mockContext.Setup(m => m.Departments).Returns(mockSet.Object);
            mockContext.Setup(x => x.SaveChanges()).Returns(0);

            _depRepositories = new DepRepositories(mockContext.Object);
            var result = _depRepositories.UpdateDepartment(dep);
            result.Result.Should().NotBeNull();
        }

        [Test]
        public void UpdateDepartmentFailed()
        {
            Department dep = new Department {DepartmentaName = "JAVA" };

            var data = new List<Department>
            {
                 /*new Department {DepartmentId =1,  DepartmentaName = "testDepartment 1" },*/
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Department>>();
            mockSet.As<IQueryable<Department>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Department>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Department>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Department>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();
            mockContext.Setup(m => m.Departments).Returns(mockSet.Object);
            mockContext.Setup(x => x.SaveChanges()).Returns(0);

            _depRepositories = new DepRepositories(mockContext.Object);
            var result = _depRepositories.UpdateDepartment(dep);
            result.Result.Should().BeNull(null);
        }

        [Test]
        public void CreateDepartmentSuccess()
        {
            Department dep = new Department { DepartmentId = 1, DepartmentaName = "xvhdv" };
            var data = new List<Department>
            {
                new Department {DepartmentId =1,  DepartmentaName = "testDepartment 1" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Department>>();
            mockSet.As<IQueryable<Department>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Department>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Department>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Department>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();
            mockContext.Setup(m => m.Departments).Returns(mockSet.Object);
            mockContext.Setup(m => m.SaveChanges()).Returns(1);

            _depRepositories = new DepRepositories(mockContext.Object);
            var result = _depRepositories.AddDepartment(dep);
            result.Result.Should().Be(1);
        }

        [Test]
        public void CreateDepartmentFailed()
        {
            Department dep = new Department { DepartmentId = 1, DepartmentaName = "xvhdv" };
            var data = new List<Department>
            {
                
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Department>>();
            mockSet.As<IQueryable<Department>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Department>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Department>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Department>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();
            mockContext.Setup(m => m.Departments).Returns(mockSet.Object);
            mockContext.Setup(m => m.SaveChanges()).Returns(0);

            _depRepositories = new DepRepositories(mockContext.Object);
            var result = _depRepositories.AddDepartment(dep);
            result.Result.Should().Be(0);
        }

        [Test]
        public void CreateDublicationDepartment()
        {
            Department dep = new Department { DepartmentId = 1, DepartmentaName = "xvhdv" };
            var data = new List<Department>
            {
                new Department {DepartmentaName = "xvhdv"}
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Department>>();
            mockSet.As<IQueryable<Department>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Department>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Department>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Department>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();
            mockContext.Setup(m => m.Departments).Returns(mockSet.Object);
            mockContext.Setup(m => m.SaveChanges()).Returns(0);

            _depRepositories = new DepRepositories(mockContext.Object);
            var result = _depRepositories.AddDepartment(dep);
            result.Result.Should().NotBeNull();
        }

        [TestCase("1")]
        public void DeleteDepartmentSuccesss(int id)
        {
            var data = new List<Department>
                    {
                        new Department {DepartmentId =1,  DepartmentaName = "testDepartment 1" },
                    }.AsQueryable();

            var mockSet = new Mock<DbSet<Department>>();
            mockSet.As<IQueryable<Department>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Department>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Department>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Department>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();
            mockContext.Setup(m => m.Departments).Returns(mockSet.Object);
     
            mockContext.Setup(m => m.SaveChanges()).Returns(1);

            _depRepositories = new DepRepositories(mockContext.Object);
            var result = _depRepositories.DeleteDepartment(id);
            result.Result.Should().Be(1);
           // result.Message.Should().Be(DepConstans.DepIDFound);
         }


        [TestCase("1")]
        public void DeleteDepartmentFailed(int id)
        {
            var data = new List<Department>
                    {
                        
                    }.AsQueryable();

            var mockSet = new Mock<DbSet<Department>>();
            mockSet.As<IQueryable<Department>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Department>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Department>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Department>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();
            mockContext.Setup(m => m.Departments).Returns(mockSet.Object);

            mockContext.Setup(m => m.SaveChanges()).Returns(1);

            _depRepositories = new DepRepositories(mockContext.Object);
            var result = _depRepositories.DeleteDepartment(id);
            result.Result.Should().Be(0);
            // result.Message.Should().Be(DepConstans.DepIDFound);
        }


        [TestCase("1")]
        public void GetDepartmentByIDSuccesss(int ID)
        {
                var data = new List<Department>
                {
               new Department {DepartmentId =1,  DepartmentaName = "testDepartment 1" },
                }.AsQueryable();
                var mockSet = new Mock<DbSet<Department>>();
                mockSet.As<IQueryable<Department>>().Setup(m => m.Provider).Returns(data.Provider);
                mockSet.As<IQueryable<Department>>().Setup(m => m.Expression).Returns(data.Expression);
                mockSet.As<IQueryable<Department>>().Setup(m => m.ElementType).Returns(data.ElementType);
                mockSet.As<IQueryable<Department>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
                var mockContext = new Mock<ApiDbContext>();
                mockContext.Setup(m => m.Departments).Returns(mockSet.Object);
                _depRepositories = new DepRepositories(mockContext.Object);

                var result = _depRepositories.GetDepartmentsById(ID);
                
                result.StatusCode.Should().Be(200);
                result.Message.Should().Be(DepConstans.DepIDFound);
                result.Result.Should().NotBeNull();
        }

        [TestCase("1")]
        public void GetDepartmentByIDFailed(int ID)
        {
            var data = new List<Department>
                {
               
                }.AsQueryable();
            var mockSet = new Mock<DbSet<Department>>();
            mockSet.As<IQueryable<Department>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Department>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Department>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Department>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<ApiDbContext>();
            mockContext.Setup(m => m.Departments).Returns(mockSet.Object);
            _depRepositories = new DepRepositories(mockContext.Object);

            var result = _depRepositories.GetDepartmentsById(ID);

            result.StatusCode.Should().Be(404);
            result.Message.Should().Be(DepConstans.DepIDnotFoud);
            result.Result.Should().BeNull();
            
            
        }
    }
}
