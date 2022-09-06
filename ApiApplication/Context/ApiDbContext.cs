using ApiApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApplication.Context
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        public virtual DbSet<UserRoleMapping> UserRoleMappings { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Salarys> Salarys { get; set; }
    }
}


//EmpDbContext