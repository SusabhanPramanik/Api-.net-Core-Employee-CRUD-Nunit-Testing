using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiApplication.Models
{
    public class Salarys
    {
        [Key]
        public int SalaryId { get; set; }
        public int UserId { get; set; }
        public double Salary { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string updatedBy { get; set; }
        public DateTime updatedDate { get; set; }

    }
}
