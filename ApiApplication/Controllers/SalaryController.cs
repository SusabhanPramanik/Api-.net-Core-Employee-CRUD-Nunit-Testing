using ApiApplication.Models;
using ApiApplication.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private readonly ISalRepositories _empRepositories;

        public SalaryController(ISalRepositories empRepositories)
        {
            _empRepositories = empRepositories;
        }
        // GET: api/<EtableController>
        [HttpGet]
        public IActionResult Get()
        {
            var salary = _empRepositories.GetSalary();
            return new OkObjectResult(salary);
        }

        // GET api/<EtableController>/5
        [HttpGet("{id}")]
        public IActionResult GetSalaryById(int id)
        {
            var response = _empRepositories.GetSalaryById(id);
            if (response.StatusCode == (int)HttpStatusCode.OK)
            {
                return new OkObjectResult(response);
            }
            return Content(response.Message);
        }

        // POST api/<EtableController>
        [HttpPost]
        public IActionResult AddSalary([FromBody] Salarys value)
        {
            using (var scope = new TransactionScope())
            {
                var response = _empRepositories.AddSalary(value);
                if (response.StatusCode == Convert.ToInt32(System.Net.HttpStatusCode.OK))
                {
                    scope.Complete();
                    return Content(response.Message);
                }

                return Content(response.Message);
            }
        }

        // PUT api/<EtableController>/5
        [HttpPut]
        public IActionResult UpdateSalary([FromBody] Salarys value)
        {
            var response = _empRepositories.UpdateSalary(value);
            if (response.StatusCode == Convert.ToInt32(System.Net.HttpStatusCode.OK))
            {
                return Content(response.Message);
            }

            return Content(response.Message);
        }

        // DELETE api/<EtableController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSalary(int id)
        {
            var response = _empRepositories.DeleteSalary(id);
            if (response.StatusCode == Convert.ToInt32(System.Net.HttpStatusCode.OK))
            {
                return Content(response.Message);
            }

            return Content(response.Message);
        }
    }
}
