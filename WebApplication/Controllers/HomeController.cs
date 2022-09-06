using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplication.Helper;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        DepHelper _api = new DepHelper();
        public async Task<IActionResult> Index()
        {
            List<DepartmentData> dep = new List<DepartmentData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/aDepartment");
            if(res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                dep = JsonConvert.DeserializeObject<List<DepartmentData>>(result);

            }
            return View(dep);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
