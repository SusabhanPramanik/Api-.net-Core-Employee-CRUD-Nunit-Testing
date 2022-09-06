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
using System.Text;
using System.Threading.Tasks;

namespace TsetProject.RoleTest
{
    public class RoleServiceUnitTest
    {
        private RoleRepositories _roleRepositories;
        private Roles roles;
        private IEnumerable<Roles> rolesList;


        [SetUp]
        public void Setup()
        {
            var mockSet = new Mock<DbSet<Roles>>();
            var mockContext = new Mock<ApiDbContext>();
            mockContext.Setup(m => m.Roles).Returns(mockSet.Object);
            _roleRepositories = new RoleRepositories(mockContext.Object);

        }

        [Test]
        public void GetAllRolesListSuccess()
        {
            var data = new List<Roles>
            {
                new Roles {RoleId = 1 , RoleName = "jegv"},
                new Roles {RoleId = 2 , RoleName = "cwsu"},
                new Roles {RoleId = 3 , RoleName = "wuhdvu"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Roles>>();
            mockSet.As<IQueryable<Roles>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Roles>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Roles>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Roles>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();

            mockContext.Setup(m => m.Roles).Returns(mockSet.Object);

            _roleRepositories = new RoleRepositories(mockContext.Object);
            var result = _roleRepositories.GetRoles();
            result.Should().HaveCountGreaterThan(2);
        }

        [Test]
        public void GetAllRolesListFailed()
        {
            var data = new List<Roles>
            {
                
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Roles>>();
            mockSet.As<IQueryable<Roles>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Roles>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Roles>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Roles>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();

            mockContext.Setup(m => m.Roles).Returns(mockSet.Object);

            _roleRepositories = new RoleRepositories(mockContext.Object);
            var result = _roleRepositories.GetRoles();
            result.Should().HaveCount(0);
        }

        [Test]
        public void UpdateRolesSuccess()
        {
            Roles rol = new Roles { RoleId = 1, RoleName = "ecge" };

            var data = new List<Roles>
            {
               new Roles {RoleId = 1 , RoleName = "jegv"},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Roles>>();
            mockSet.As<IQueryable<Roles>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Roles>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Roles>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Roles>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();

            mockContext.Setup(m => m.Roles).Returns(mockSet.Object);
            mockContext.Setup(m => m.SaveChanges()).Returns(1);
            _roleRepositories = new RoleRepositories(mockContext.Object);
            var result = _roleRepositories.UpdateRoles(rol);
            result.Result.Should().Be(null);
        }

        [Test]
        public void UpdateRolesFailed()
        {
            Roles rol = new Roles { RoleId = 1, RoleName = "ecge" };

            var data = new List<Roles>
            {
               
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Roles>>();
            mockSet.As<IQueryable<Roles>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Roles>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Roles>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Roles>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();

            mockContext.Setup(m => m.Roles).Returns(mockSet.Object);
            mockContext.Setup(m => m.SaveChanges()).Returns(1);
            _roleRepositories = new RoleRepositories(mockContext.Object);
            var result = _roleRepositories.UpdateRoles(rol);
            result.Result.Should().BeNull(null);
        }

        [Test]
        public void CreateRoleSuccess()
        {
            Roles rol = new Roles { RoleId = 1, RoleName = "ecge" };
            var data = new List<Roles>
            {
                new Roles { RoleId = 1, RoleName = "TestRole 1" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Roles>>();
            mockSet.As<IQueryable<Roles>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Roles>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Roles>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Roles>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();

            mockContext.Setup(m => m.Roles).Returns(mockSet.Object);
            mockContext.Setup(m => m.SaveChanges()).Returns(1);

            _roleRepositories = new RoleRepositories(mockContext.Object);
            var result = _roleRepositories.AddRoles(rol);
            result.Result.Should().Be(1);
        }

        [Test]
        public void CreateRoleSFailed()
        {
            Roles rol = new Roles { RoleId = 1, RoleName = "ecge" };
            var data = new List<Roles>
            {
             
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Roles>>();
            mockSet.As<IQueryable<Roles>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Roles>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Roles>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Roles>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();

            mockContext.Setup(m => m.Roles).Returns(mockSet.Object);
            mockContext.Setup(m => m.SaveChanges()).Returns(0);

            _roleRepositories = new RoleRepositories(mockContext.Object);
            var result = _roleRepositories.AddRoles(rol);
            result.Result.Should().Be(0);
        }

        [TestCase("1")]
        public void DeleteRoleSuccess(int id)
        {
            var data = new List<Roles>
            {
                new Roles { RoleId = 1, RoleName = "ecge" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Roles>>();
            mockSet.As<IQueryable<Roles>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Roles>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Roles>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Roles>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();

            mockContext.Setup(m => m.Roles).Returns(mockSet.Object);
            mockContext.Setup(m => m.SaveChanges()).Returns(1);

            _roleRepositories = new RoleRepositories(mockContext.Object);
            var result = _roleRepositories.DeleteRoles(id);
            result.Result.Should().Be(1);
        }

        [TestCase("1")]
        public void DeleteRoleFailed(int id)
        {
            var data = new List<Roles>
            {
                
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Roles>>();
            mockSet.As<IQueryable<Roles>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Roles>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Roles>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Roles>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();

            mockContext.Setup(m => m.Roles).Returns(mockSet.Object);
            mockContext.Setup(m => m.SaveChanges()).Returns(1);

            _roleRepositories = new RoleRepositories(mockContext.Object);
            var result = _roleRepositories.DeleteRoles(id);
            result.Result.Should().Be(0);
        }

        [TestCase("1")]
        public void GetRoleByIdSuccess(int id)
        {
            var data = new List<Roles>
            {
                new Roles { RoleId = 1, RoleName = "ecge" },
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Roles>>();
            mockSet.As<IQueryable<Roles>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Roles>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Roles>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Roles>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();

            mockContext.Setup(m => m.Roles).Returns(mockSet.Object);
            mockContext.Setup(m => m.SaveChanges()).Returns(1);

            _roleRepositories = new RoleRepositories(mockContext.Object);
            var result = _roleRepositories.GetRolesById(id);
            result.StatusCode.Should().Be(200);
            result.Message.Should().Be(DepConstans.RoleIDFound);
            result.Result.Should().NotBeNull();
        }

        [TestCase("1")]
        public void GetRoleByIdFailed(int id)
        {
            var data = new List<Roles>
            {
               
            }.AsQueryable();
            var mockSet = new Mock<DbSet<Roles>>();
            mockSet.As<IQueryable<Roles>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Roles>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Roles>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Roles>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();

            mockContext.Setup(m => m.Roles).Returns(mockSet.Object);
            mockContext.Setup(m => m.SaveChanges()).Returns(1);

            _roleRepositories = new RoleRepositories(mockContext.Object);
            var result = _roleRepositories.GetRolesById(id);
            result.StatusCode.Should().Be(404);
            result.Message.Should().Be(DepConstans.RoleIdNotFound);
            result.Result.Should().BeNull();
        }
    }
}
