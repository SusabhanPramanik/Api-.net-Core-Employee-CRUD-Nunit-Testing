using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApplication.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public DateTime dateofbirth { get; set; }
        public int employeeCode { get; set; }
        public int DepartmentId { get; set; }
        public string Password { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string updatedBy { get; set; }
        public DateTime updatedDate { get; set; }

    }
}