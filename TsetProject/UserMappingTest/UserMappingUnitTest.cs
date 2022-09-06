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

namespace TsetProject.UserMappingTest
{
    public class UserMappingUnitTest
    {
        private UserMapingRepositories _userMapping;
        private UserRoleMapping userRoleMapping;
        private IEnumerable<UserRoleMapping> userRoleMappingsList;


        [SetUp]
        public void Setup()
        {
            var mocSet = new Mock<DbSet<UserRoleMapping>>();

            var mockContext = new Mock<ApiDbContext>();

            mockContext.Setup(m => m.UserRoleMappings).Returns(mocSet.Object);

            _userMapping = new UserMapingRepositories(mockContext.Object);
        }

        [Test]
        public void GetAllUserRoleMappingReturnSuccess()
        {
            var data = new List<UserRoleMapping>
            {
                new UserRoleMapping { UserRoleMappingId = 1,UserId = 21, RoleId = 23 },
                new UserRoleMapping { UserRoleMappingId = 2,UserId = 21, RoleId = 23 },
                new UserRoleMapping { UserRoleMappingId = 3,UserId = 21, RoleId = 23 },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<UserRoleMapping>>();
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();

            mockContext.Setup(m => m.UserRoleMappings).Returns(mockSet.Object);

            _userMapping = new UserMapingRepositories(mockContext.Object);

            var result = _userMapping.GetUserRoleMapping();

            result.Should().HaveCountGreaterThan(2);
        }

        [Test]
        public void GetAllUserRoleMappingReturnFailed()
        {
            var data = new List<UserRoleMapping>
            {
                
            }.AsQueryable();

            var mockSet = new Mock<DbSet<UserRoleMapping>>();
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();

            mockContext.Setup(m => m.UserRoleMappings).Returns(mockSet.Object);

            _userMapping = new UserMapingRepositories(mockContext.Object);

            var result = _userMapping.GetUserRoleMapping();

            result.Should().HaveCount(0);
        }

        [Test]
        public void UpdateUserRoleMappingReturnSuccess()
        {
            UserRoleMapping dep = new UserRoleMapping { UserRoleMappingId = 1, UserId = 21, RoleId = 23 };
            var data = new List<UserRoleMapping>
            {
                new UserRoleMapping { UserRoleMappingId = 1,UserId = 21, RoleId = 23 },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<UserRoleMapping>>();
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();

            mockContext.Setup(m => m.UserRoleMappings).Returns(mockSet.Object);
            mockContext.Setup(x => x.SaveChanges()).Returns(1);

            _userMapping = new UserMapingRepositories(mockContext.Object);

            var result = _userMapping.UpdateUserRoleMapping(dep);

            result.Result.Should().Be(null);
        }

        [Test]
        public void UpdateUserRoleMappingReturnFailed()
        {
            UserRoleMapping dep = new UserRoleMapping { UserRoleMappingId = 1, UserId = 21, RoleId = 23 };
            var data = new List<UserRoleMapping>
            {

            }.AsQueryable();

            var mockSet = new Mock<DbSet<UserRoleMapping>>();
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();

            mockContext.Setup(m => m.UserRoleMappings).Returns(mockSet.Object);
            mockContext.Setup(x => x.SaveChanges()).Returns(0);

            _userMapping = new UserMapingRepositories(mockContext.Object);

            var result = _userMapping.UpdateUserRoleMapping(dep);

            result.Result.Should().Be(null);
        }

        [Test]
        public void CreateUserRoleMappingReturnSuccess()
        {
            UserRoleMapping dep = new UserRoleMapping { UserRoleMappingId = 1, UserId = 21, RoleId = 23 };
            var data = new List<UserRoleMapping>
            {
                 new UserRoleMapping { UserRoleMappingId = 1,UserId = 43, RoleId = 30 },

            }.AsQueryable();

            var mockSet = new Mock<DbSet<UserRoleMapping>>();
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();

            mockContext.Setup(m => m.UserRoleMappings).Returns(mockSet.Object);
            mockContext.Setup(x => x.SaveChanges()).Returns(1);

            _userMapping = new UserMapingRepositories(mockContext.Object);

            var result = _userMapping.AddUserRoleMapping(dep);

            result.Result.Should().Be(1);
        }

        [Test]
        public void CreateUserRoleMappingReturnFailed()
        {
            UserRoleMapping dep = new UserRoleMapping { UserRoleMappingId = 1, UserId = 21, RoleId = 23 };
            var data = new List<UserRoleMapping>
            {

            }.AsQueryable();

            var mockSet = new Mock<DbSet<UserRoleMapping>>();
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();

            mockContext.Setup(m => m.UserRoleMappings).Returns(mockSet.Object);
            mockContext.Setup(x => x.SaveChanges()).Returns(0);

            _userMapping = new UserMapingRepositories(mockContext.Object);

            var result = _userMapping.AddUserRoleMapping(dep);

            result.Result.Should().Be(0);
        }

        [TestCase("1")]
        public void DeleteUserRoleMappingReturnSuccess(int id)
        {
            UserRoleMapping dep = new UserRoleMapping { UserRoleMappingId = 1, UserId = 21, RoleId = 23 };
            var data = new List<UserRoleMapping>
            {
               new UserRoleMapping { UserRoleMappingId = 1,UserId = 21, RoleId = 23 },

            }.AsQueryable();

            var mockSet = new Mock<DbSet<UserRoleMapping>>();
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();

            mockContext.Setup(m => m.UserRoleMappings).Returns(mockSet.Object);
            mockContext.Setup(x => x.SaveChanges()).Returns(1);

            _userMapping = new UserMapingRepositories(mockContext.Object);

            var result = _userMapping.DeleteUserRoleMapping(id);

            result.Result.Should().NotBeNull();
        }

        [TestCase("1")]
        public void DeleteUserRoleMappingReturnFailed(int id)
        {
            UserRoleMapping dep = new UserRoleMapping { UserRoleMappingId = 1, UserId = 21, RoleId = 23 };
            var data = new List<UserRoleMapping>
            {

            }.AsQueryable();

            var mockSet = new Mock<DbSet<UserRoleMapping>>();
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();

            mockContext.Setup(m => m.UserRoleMappings).Returns(mockSet.Object);
            mockContext.Setup(x => x.SaveChanges()).Returns(0);

            _userMapping = new UserMapingRepositories(mockContext.Object);

            var result = _userMapping.DeleteUserRoleMapping(id);

            result.Result.Should().BeNull();
        }

        [TestCase("1")]
        public void GetUserRoleMappingByIdReturnSuccess(int id)
        {
            UserRoleMapping dep = new UserRoleMapping { UserRoleMappingId = 1, UserId = 21, RoleId = 23 };
            var data = new List<UserRoleMapping>
            {
               new UserRoleMapping { UserRoleMappingId = 1,UserId = 32, RoleId = 43 },

            }.AsQueryable();

            var mockSet = new Mock<DbSet<UserRoleMapping>>();
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();

            mockContext.Setup(m => m.UserRoleMappings).Returns(mockSet.Object);
            mockContext.Setup(x => x.SaveChanges()).Returns(1);

            _userMapping = new UserMapingRepositories(mockContext.Object);

            var result = _userMapping.GetUserRoleMappingById(id);

            result.Result.Should().NotBeNull();
        }

        [TestCase("1")]
        public void GetUserRoleMappingByIdReturnFailed(int id)
        {
            UserRoleMapping dep = new UserRoleMapping { UserRoleMappingId = 1, UserId = 21, RoleId = 23 };
            var data = new List<UserRoleMapping>
            {

            }.AsQueryable();

            var mockSet = new Mock<DbSet<UserRoleMapping>>();
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<UserRoleMapping>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();

            mockContext.Setup(m => m.UserRoleMappings).Returns(mockSet.Object);
            mockContext.Setup(x => x.SaveChanges()).Returns(0);

            _userMapping = new UserMapingRepositories(mockContext.Object);

            var result = _userMapping.GetUserRoleMappingById(id);

            result.Result.Should().BeNull();
        }
    }


    
}
