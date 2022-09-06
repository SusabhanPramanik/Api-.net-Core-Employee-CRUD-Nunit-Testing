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

namespace TsetProject.SalaryTest
{
    public class SalaryServiceUnitTest
    {
        private SalRepositorie _salRepositorie;
        private Salarys _salarys;
        private IEnumerable<Salarys> salaryList;

        [SetUp]
        public void Setup()
        {
            var mockTest = new Mock<DbSet<Salarys>>();
            var mockContext = new Mock<ApiDbContext>();

            mockContext.Setup(m => m.Salarys).Returns(mockTest.Object);

            _salRepositorie = new SalRepositorie(mockContext.Object);
            
        }

        [Test]
        public void GetAllSalarysReturnSuccess()
        {
            var data = new List<Salarys>
            {
                new Salarys {SalaryId = 1, UserId = 3478, Salary = 347364, CreatedBy = "ugrvfy", CreatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955"),updatedBy = "dekbc", updatedDate =Convert.ToDateTime("2022-07-20 05:59:21.955")},
                new Salarys {SalaryId = 2, UserId = 3477, Salary = 347364, CreatedBy = "ugrvfy", CreatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955"),updatedBy = "dekbc", updatedDate =Convert.ToDateTime("2022-07-20 05:59:21.955")},
                new Salarys {SalaryId = 1, UserId = 3478, Salary = 347364, CreatedBy = "ugrvfy", CreatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955"),updatedBy = "dekbc", updatedDate =Convert.ToDateTime("2022-07-20 05:59:21.955")},
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Salarys>>();
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();
            mockContext.Setup(m => m.Salarys).Returns(mockSet.Object);
            _salRepositorie = new SalRepositorie(mockContext.Object);
            var result = _salRepositorie.GetSalary();
            result.Should().HaveCountGreaterThan(2);
        }

        [Test]
        public void GetAllSalarysReturnFailed()
        {
            var data = new List<Salarys>
            {
               
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Salarys>>();
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();
            mockContext.Setup(m => m.Salarys).Returns(mockSet.Object);
            _salRepositorie = new SalRepositorie(mockContext.Object);
            var result = _salRepositorie.GetSalary();
            result.Should().HaveCount(0);
        }

        [Test]
        public void UpdateSalarySuccess()
        {
            var Sal = new Salarys{ SalaryId = 1, UserId = 3478, Salary = 347364, CreatedBy = "ugrvfy", CreatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955"), updatedBy = "dekbc", updatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955") };
            var data = new List<Salarys>
            {
              new Salarys {SalaryId = 1, UserId = 3477, Salary = 347364, CreatedBy = "ugrvfy", CreatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955"),updatedBy = "dekbc", updatedDate =Convert.ToDateTime("2022-07-20 05:59:21.955")},

            }.AsQueryable();

            var mockSet = new Mock<DbSet<Salarys>>();
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();
            mockContext.Setup(m => m.Salarys).Returns(mockSet.Object);
            mockContext.Setup(m => m.SaveChanges()).Returns(1);
            _salRepositorie = new SalRepositorie(mockContext.Object);
            var result = _salRepositorie.UpdateSalary(Sal);
            result.Result.Should().Be(null);
        }

        [Test]
        public void UpdateSalaryFailed()
        {
            var Sal = new Salarys { SalaryId = 1, UserId = 3478, Salary = 347364, CreatedBy = "ugrvfy", CreatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955"), updatedBy = "dekbc", updatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955") };
            var data = new List<Salarys>
            {

            }.AsQueryable();

            var mockSet = new Mock<DbSet<Salarys>>();
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();
            mockContext.Setup(m => m.Salarys).Returns(mockSet.Object);
            mockContext.Setup(m => m.SaveChanges()).Returns(0);
            _salRepositorie = new SalRepositorie(mockContext.Object);
            var result = _salRepositorie.UpdateSalary(Sal);
            result.Result.Should().BeNull();
        }

        [Test]
        public void CretaeSalarySuccess()
        {
            var Sal = new Salarys { SalaryId = 1, UserId = 3478, Salary = 347364, CreatedBy = "ugrvfy", CreatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955"), updatedBy = "dekbc", updatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955") };
            var data = new List<Salarys>
            {
              new Salarys {SalaryId = 1, UserId = 3477, Salary = 347364, CreatedBy = "ugrvfy", CreatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955"),updatedBy = "dekbc", updatedDate =Convert.ToDateTime("2022-07-20 05:59:21.955")},

            }.AsQueryable();

            var mockSet = new Mock<DbSet<Salarys>>();
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();
            mockContext.Setup(m => m.Salarys).Returns(mockSet.Object);
            mockContext.Setup(m => m.SaveChanges()).Returns(1);
            _salRepositorie = new SalRepositorie(mockContext.Object);
            var result = _salRepositorie.AddSalary(Sal);
            result.Result.Should().Be(1);
        }

        [Test]
        public void CretaeSalaryFailed()
        {
            var Sal = new Salarys { SalaryId = 1, UserId = 3478, Salary = 347364, CreatedBy = "ugrvfy", CreatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955"), updatedBy = "dekbc", updatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955") };
            var data = new List<Salarys>
            {

            }.AsQueryable();

            var mockSet = new Mock<DbSet<Salarys>>();
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();
            mockContext.Setup(m => m.Salarys).Returns(mockSet.Object);
            mockContext.Setup(m => m.SaveChanges()).Returns(0);
            _salRepositorie = new SalRepositorie(mockContext.Object);
            var result = _salRepositorie.AddSalary(Sal);
            result.Result.Should().BeNull();
        }

        [TestCase("1")]
        public void DeleteSalarySuccess(int id)
        {
            var data = new List<Salarys>
            {
              new Salarys {SalaryId = 1, UserId = 3477, Salary = 347364, CreatedBy = "ugrvfy", CreatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955"),updatedBy = "dekbc", updatedDate =Convert.ToDateTime("2022-07-20 05:59:21.955")},

            }.AsQueryable();

            var mockSet = new Mock<DbSet<Salarys>>();
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();
            mockContext.Setup(m => m.Salarys).Returns(mockSet.Object);
            mockContext.Setup(m => m.SaveChanges()).Returns(1);
            _salRepositorie = new SalRepositorie(mockContext.Object);
            var result = _salRepositorie.DeleteSalary(id);
            result.StatusCode.Should().Be(200);
            result.Result.Should().NotBeNull();
        }

        [TestCase("1")]
        public void DeleteSalaryFailed(int id)
        {
            var data = new List<Salarys>
            {

            }.AsQueryable();

            var mockSet = new Mock<DbSet<Salarys>>();
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();
            mockContext.Setup(m => m.Salarys).Returns(mockSet.Object);
            mockContext.Setup(m => m.SaveChanges()).Returns(0);
            _salRepositorie = new SalRepositorie(mockContext.Object);
            var result = _salRepositorie.DeleteSalary(id);
            result.StatusCode.Should().Be(500);
            result.Result.Should().BeNull();
        }

        [TestCase("1")]
        public void GetSalaryByIdSuccess(int id)
        {
            var data = new List<Salarys>
            {
              new Salarys {SalaryId = 1, UserId = 3477, Salary = 347364, CreatedBy = "ugrvfy", CreatedDate = Convert.ToDateTime("2022-07-20 05:59:21.955"),updatedBy = "dekbc", updatedDate =Convert.ToDateTime("2022-07-20 05:59:21.955")},

            }.AsQueryable();

            var mockSet = new Mock<DbSet<Salarys>>();
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();
            mockContext.Setup(m => m.Salarys).Returns(mockSet.Object);
            mockContext.Setup(m => m.SaveChanges()).Returns(1);
            _salRepositorie = new SalRepositorie(mockContext.Object);
            var result = _salRepositorie.GetSalaryById(id);
            result.StatusCode.Should().Be(200);
            result.Result.Should().NotBeNull();
        }

        [TestCase("1")]
        public void GetSalaryByIdFailed(int id)
        {
            var data = new List<Salarys>
            {

            }.AsQueryable();

            var mockSet = new Mock<DbSet<Salarys>>();
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Salarys>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<ApiDbContext>();
            mockContext.Setup(m => m.Salarys).Returns(mockSet.Object);
            mockContext.Setup(m => m.SaveChanges()).Returns(1);
            _salRepositorie = new SalRepositorie(mockContext.Object);
            var result = _salRepositorie.GetSalaryById(id);
            result.StatusCode.Should().Be(404);
            result.Result.Should().BeNull();
        }
    }
}
